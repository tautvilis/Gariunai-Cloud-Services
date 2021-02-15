using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly WebApiContext _context;

        public ImagesController(WebApiContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<ActionResult<Guid>> PostImage(IFormFile image)
        {
            await using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);
            
            if(memoryStream.Length < 10000000)
            {
                var img = new Image()
                {
                    Suffix = Path.GetExtension(image.FileName),
                    Data = memoryStream.ToArray()
                };

                await _context.Images.AddAsync(img);
                await _context.SaveChangesAsync();
                return img.Id;
            }
            else
            {
                return BadRequest("Image too big");
            }
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetImage(Guid guid)
        {
            
            var image = await _context.Images
                .FromSqlInterpolated($"SELECT * from dbo.Images WHERE id = {guid}")
                .FirstOrDefaultAsync();
            
            if (image == null)
            {
                return NotFound("Image not found" + guid);
            }
            
            return File(image.Data, $"image/{image.Suffix.Replace(".", "").ToLower()}");
        }
        
        [HttpDelete("{guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteImage(Guid guid)
        {

            if (_context.Users.First(u => u.Id == AuthenticatedUserId()).Name != "Admin")
            {
                return Unauthorized("Must be an admin to perform this action");
            }

            await _context.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM dbo.Images WHERE id = {guid}");

            return Ok();
        }
        private int AuthenticatedUserId()
        {
            return int.Parse(HttpContext.User.Identity.Name ?? "-1");
        }
    }
}