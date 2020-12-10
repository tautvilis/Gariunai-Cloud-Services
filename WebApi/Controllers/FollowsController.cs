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
    [Authorize]
    public class FollowsController : ControllerBase
    {
        private readonly WebApiContext _context;
        private readonly IMapper _mapper;

        public FollowsController(WebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Follows
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<FollowDTO>>> GetFollow()
        {
            var follows =  _context.Follows
                .Where(f => f.UserId == AuthenticatedUserId())
                .ToListAsync();

            return _mapper.Map<List<FollowDTO>>(await follows);
        }
        
        private int AuthenticatedUserId()
        {
            return int.Parse(HttpContext.User.Identity.Name ?? "-1");
        }
    }
}