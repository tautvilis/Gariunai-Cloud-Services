using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducesController : ControllerBase
    {
        private readonly WebApiContext _context;

        public ProducesController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Produces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produce>>> GetProduce()
        {
            return await _context.Produce.ToListAsync();
        }

        // GET: api/Produces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produce>> GetProduce(int id)
        {
            var produce = await _context.Produce.FindAsync(id);

            if (produce == null)
            {
                return NotFound();
            }

            return produce;
        }

        // PUT: api/Produces/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduce(int id, Produce produce)
        {
            if (id != produce.Id)
            {
                return BadRequest();
            }

            _context.Entry(produce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produces
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Produce>> PostProduce(Produce produce)
        {
            _context.Produce.Add(produce);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduce", new { id = produce.Id }, produce);
        }

        // DELETE: api/Produces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produce>> DeleteProduce(int id)
        {
            var produce = await _context.Produce.FindAsync(id);
            if (produce == null)
            {
                return NotFound();
            }

            _context.Produce.Remove(produce);
            await _context.SaveChangesAsync();

            return produce;
        }

        private bool ProduceExists(int id)
        {
            return _context.Produce.Any(e => e.Id == id);
        }
    }
}
