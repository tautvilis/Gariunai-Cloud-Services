using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class MiscController : ControllerBase
    {
        private readonly WebApiContext _context;

        public MiscController(WebApiContext context)
        {
            _context = context;
        }

        public class TopShop
        {
            public int ShopId { get; set; }
            public string ShopName { get; set; }
            public int FollowerCount { get; set; }
        }

        [HttpGet("mostFollowedShops/{skip}/{limit}")]
        public async Task<ActionResult<IEnumerable<TopShop>>> GetImage(int skip, int limit)
        {
            var result =
                (from x in
                        (from s in _context.Shops
                            join f in _context.Follows
                                on s.Id equals f.ShopId
                            select new
                            {
                                shopId = s.Id,
                                shopName = s.Name,
                                follower = f.UserId
                            })
                    group x by new {x.shopId, x.shopName}
                    into shops
                    select new TopShop()
                    {
                        ShopId = shops.Key.shopId,
                        ShopName = shops.Key.shopName,
                        FollowerCount = shops.Count()
                    })
                .OrderByDescending(s => s.FollowerCount)
                .Skip(skip)
                .Take(limit)
                .ToListAsync();
            return await result;
        }
    }
}