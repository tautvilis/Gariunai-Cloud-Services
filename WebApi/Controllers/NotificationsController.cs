using System;
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
    public class NotificationsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public NotificationsController(WebApiContext context)
        {
            _context = context;
        }
        
        
        [HttpGet("{userName}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Notification>>> GetUsersNotification(string userName)
        {

            var user = _context.Users.FirstOrDefault(u => u.Name == userName);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (user.Id != AuthenticatedUserId())
            {
                return Unauthorized();
            }

            var notifications = _context.Notifications.Where(n =>
                    _context.Follows.Where(f => f.UserId == user.Id).Select(f => f.ShopId).Contains(n.ShopId))
                .ToListAsync();

            return await notifications;
        }
        
        private int AuthenticatedUserId()
        {
            return int.Parse(HttpContext.User.Identity.Name ?? "-1");
        }
    }
}
