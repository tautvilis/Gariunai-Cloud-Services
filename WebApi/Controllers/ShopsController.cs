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
    public class ShopsController : ControllerBase
    {
        private readonly WebApiContext _context;
        private readonly IMapper _mapper;

        public ShopsController(WebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Shops
        [HttpGet]
        public async Task<ActionResult<List<ShopDTO>>> GetShops()
        {
            var shops =  await _context.Shops.Include(s => s.Produce).ToListAsync();
            return _mapper.Map<List<ShopDTO>>(shops);
        }

        // GET: api/Shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopDTO>> GetShop(int id)
        {
            var shop = await _context.Shops
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (shop == null)
            {
                return NotFound();
            }
            
            return _mapper.Map<ShopDTO>(shop);
        }
        
        // POST: api/Shops
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Shop>> PostShop(ShopDTO shop)
        {

            if (shop.OwnerId != AuthenticatedUserId())
            {
                return Unauthorized("Shop does not belong to you");
            }

            await _context.Shops.AddAsync(_mapper.Map<Shop>(shop));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShop", new { id = shop.Id }, shop);
        }

        // PUT: api/Shops/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutShop(int id, [FromBody] ShopDTO shop)
        {
            if (id != shop.Id)
            {
                return BadRequest();
            }

            if (shop.OwnerId != AuthenticatedUserId())
            {
                return Unauthorized("Shop does not belong to you");
            }

            _context.Entry(_mapper.Map<Shop>(shop)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        
        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Shop>> DeleteShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            
            if (shop == null)
            {
                return NotFound();
            }
            
            if (shop.OwnerId != AuthenticatedUserId())
            {
                return Unauthorized("Shop does not belong to you");
            }
            
            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();

            return shop;
        }
        
        //----------------produce-------------------
        
        // GET: api/Shops/{id}/Produce
        [HttpGet("{id}/Produce")]
        public async Task<ActionResult<List<ProduceDTO>>> GetProduce(int id)
        {
            if (!ShopExists(id))
            {
                return NotFound();
            }

            var produce = await _context.Produce.Where(p => p.ShopId == id).ToListAsync();
            return _mapper.Map<List<ProduceDTO>>(produce);
        }
        
        // POST: api/Shops/{id}/Produce
        [HttpPost("{id}/Produce")]
        [Authorize]
        public async Task<ActionResult<ProduceDTO>> PostProduce(int id, [FromBody] ProduceDTO produceDTO)
        {
            var shop = await _context.Shops.FindAsync(id);
            
            if (shop == null)
            {
                return NotFound();
            }
            
            if (shop.OwnerId != AuthenticatedUserId())
            {
                return Unauthorized("Shop does not belong to you");
            }

            if (_context.Produce.Any(p => p.ShopId == id && p.Name == produceDTO.Name))
            {
                return BadRequest("Produce with same name already in shop");
            }

            var produce = _mapper.Map<Produce>(produceDTO);
            produce.ShopId = id;

            await _context.Produce.AddAsync(produce);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProduceDTO>(produce);
        }
        
        // DELETE: api/Shops/{id}/Produce
        [HttpDelete("{id}/Produce")]
        [Authorize]
        public async Task<IActionResult> RemoveProduce(int id, [FromBody] ProduceDTO produceDTO)
        {
            var shop = await _context.Shops.FindAsync(id);
            
            if (shop == null)
            {
                return NotFound();
            }
            
            if (shop.OwnerId != AuthenticatedUserId())
            {
                return Unauthorized("Shop does not belong to you");
            }

            var produce = await _context.Produce
                .Where(p => p.ShopId == id && p.Name == produceDTO.Name)
                .FirstOrDefaultAsync();

            if (produce == null)
            {
                return BadRequest("No such produce");
            }

            _context.Remove(produce);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        //-----------------------notifications----------------------
        
         // GET: api/Shops/{id}/Notifications
        [HttpGet("{id}/Notifications")]
        public async Task<ActionResult<List<NotificationDTO>>> GetNotifications(int id)
        {
            if (!ShopExists(id))
            {
                return NotFound();
            }

            var notifications = await _context.Notifications.Where(n => n.ShopId == id).ToListAsync();
            return _mapper.Map<List<NotificationDTO>>(notifications);
        }
        
        // POST: api/Shops/{id}/Produce
        [HttpPost("{id}/Notifications")]
        [Authorize]
        public async Task<ActionResult<NotificationDTO>> PostNotification(int id, [FromBody] NotificationDTO notificationDTO)
        {
            var shop = await _context.Shops.FindAsync(id);
            
            if (shop == null)
            {
                return NotFound();
            }
            
            if (shop.OwnerId != AuthenticatedUserId())
            {
                return Unauthorized("Shop does not belong to you");
            }

            var notification = _mapper.Map<Produce>(notificationDTO);
            notification.ShopId = id;

            await _context.Produce.AddAsync(notification);
            await _context.SaveChangesAsync();

            return _mapper.Map<NotificationDTO>(notification);
        }
        
        // PUT: api/Shops/{id}/Produce
        [HttpPut("{id}/Notifications")]
        [Authorize]
        public async Task<ActionResult<NotificationDTO>> PutNotification(int id, [FromBody] NotificationDTO notificationDTO)
        {
            var shop = await _context.Shops.FindAsync(id);
            
            if (shop == null)
            {
                return NotFound();
            }
            
            if (shop.OwnerId != AuthenticatedUserId())
            {
                return Unauthorized("Shop does not belong to you");
            }

            _context.Entry(_mapper.Map<Notification>(notificationDTO)).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
        // DELETE: api/Shops/{id}/{notificationId}
        [HttpDelete("{id}/Notification")]
        [Authorize]
        public async Task<IActionResult> DeleteNotification(int id, int notificationId)
        {
            var shop = await _context.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound();
            }

            if (shop.OwnerId != AuthenticatedUserId())
            {
                return Unauthorized("Shop does not belong to you");
            }

            var notification = await _context.Notifications
                .Where(n => n.Id == notificationId)
                .FirstOrDefaultAsync();

            if (notification == null)
            {
                return BadRequest("Notification not found");
            }

            _context.Remove(notification);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        //------------------------follow----------------------
        [HttpGet("{id}/Follow"), Authorize]
        public async Task<ActionResult<bool>> GetFollowStatus(int id)
        {
            var shop = await _context.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound("Shop not found");
            }

            return await _context.Follows.AnyAsync(f => f.UserId == AuthenticatedUserId() && f.ShopId == id);
        }

        [HttpPost("{id}/Follow/{status}")]
        [Authorize]
        public async Task<ActionResult<bool>> SetFollowStatus(int id, bool status)
        {
            var shop = await _context.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound("Shop not found");
            }

            var currentFollow = await _context.Follows
                .Where(f => f.UserId == AuthenticatedUserId() && f.ShopId == id)
                .FirstOrDefaultAsync();

            if (currentFollow == null)
            {
                var newFollow = new Follow()
                {
                    ShopId = id,
                    UserId = AuthenticatedUserId()
                };

                _context.Add(newFollow);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Remove(currentFollow);
                await _context.SaveChangesAsync();
            }

            return status;
        }


        private bool ShopExists(int id)
        {
            return _context.Shops.Any(e => e.Id == id);
        }
        
        private int AuthenticatedUserId()
        {
            return int.Parse(HttpContext.User.Identity.Name ?? "-1");
        }
    }
}
