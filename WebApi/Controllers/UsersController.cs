using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Handlers;
using WebApi.Models;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly WebApiContext _context;
        private readonly ISalter _salter;
        private SaltAgorithm _saltAgorithm;

        public UsersController(WebApiContext context, ISalter salter)
        {
            _context = context;
            _salter = salter;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        
        // GET: api/Users/Authorize
        [HttpGet("Authorize")]
        [Authorize]
        public async Task<ActionResult<bool>> CheckAuthorization()
        {
            return true;
        }
        // POST: api/Users/RegisterUser
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Name))
                    throw new ArgumentNullException(nameof(user.Name));
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentNullException(nameof(password), "cannot be null or empty");
                if (CheckIfUsernameTaken(user.Name))
                    return StatusCode(406);
                var salt = _salter.CreateSalt();
                if(_saltAgorithm == null)
                    _saltAgorithm = new SaltAgorithm();
                BasicAuthenticationHandler.Hashing hashdelegate = _saltAgorithm.Hash;
                var hash = _salter.GenerateSaltedHash(password, salt,hashdelegate);
                _context.Users.Add(user);
                _context.SaveChanges();
                var fetcheduser = _context.Users.FirstOrDefault(u => u.Name == user.Name);
                var userPassword = new Password {Hash = hash, UserId = fetcheduser.Id, Salt = salt};
                await _context.Passwords.AddAsync(userPassword);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUser", new {id = user.Id}, user);
            }
            catch (ArgumentNullException e)
            {
                return BadRequest();
            }
            
        }
        private bool CheckIfUsernameTaken(string username)
        {
            return _context.Users.Count(user => user.Name == username) > 0;
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        
    }
}
