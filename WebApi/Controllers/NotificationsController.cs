using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.DataTransferObjects;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly WebApiContext _context;
        private readonly IMapper _mapper;

        public NotificationsController(WebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<NotificationDto>>> GetUsersNotification()
        {
            var notifications = _context.Notifications
                .Where(
                    n =>
                        _context.Follows.Where(f => f.UserId == AuthenticatedUserId()).Select(f => f.ShopId).Contains(n.ShopId))
                .ToListAsync();

            return _mapper.Map<List<NotificationDto>>(await notifications);
        }
        
        private int AuthenticatedUserId()
        {
            return int.Parse(HttpContext.User.Identity.Name ?? "-1");
        }
    }
}
