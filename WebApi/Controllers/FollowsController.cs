using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public FollowsController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Follows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follow>>> GetFollow()
        {
            return  await _context.Follows
                .Where(f => f.UserId == AuthenticatedUserId())
                .ToListAsync();
        }

        // GET: api/Follows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follow>> GetFollow(int id)
        {
            var follow = await _context.Follows.FindAsync(id);

            if (follow == null)
            {
                return NotFound();
            }

            if (follow.Id != AuthenticatedUserId())
            {
                return Unauthorized();
            }
            
            return follow;
        }
        
        // POST: api/Follows
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Follow>> PostFollow(Follow follow)
        {

            follow.UserId = AuthenticatedUserId();
            
            await _context.Follows.AddAsync(follow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollow", new { id = follow.Id }, follow);
        }

        // DELETE: api/Follows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Follow>> DeleteFollow(int id)
        {
            
            if(id != AuthenticatedUserId())
            {
                return Unauthorized();
            }
            var follow = await _context.Follows.FindAsync(id);
            if (follow == null)
            {
                return NotFound();
            }

            _context.Follows.Remove(follow);
            await _context.SaveChangesAsync();

            return follow;
        }

        private int AuthenticatedUserId()
        {
            return int.Parse(HttpContext.User.Identity.Name ?? "-1");
        }
    }
}