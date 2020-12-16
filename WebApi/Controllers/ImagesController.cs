using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
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
            
            var image = await _context.Images.FirstOrDefaultAsync(i => i.Id == guid);
            if (image == null)
            {
                return NotFound("Image not found" + guid);
            }
            
            return File(image.Data, $"image/{image.Suffix.Replace(".", "").ToLower()}");
        }
    }
}