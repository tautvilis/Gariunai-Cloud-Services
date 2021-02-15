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
    }
}
