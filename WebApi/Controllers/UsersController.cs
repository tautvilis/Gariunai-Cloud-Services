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
using WebApi.Models;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly WebApiContext _context;

        public UsersController(WebApiContext context)
        {
            _context = context;
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
        public async Task<ActionResult<User>> RegisterUser(string username, [FromBody] string password)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty", nameof(password));

            if (CheckIfUsernameTaken(username))
                return StatusCode(406);
            var salt = CreateSalt();
            var hash = GenerateSaltedHash(password, salt);
            var newUser = new User {Name = username};
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            var user = _context.Users.FirstOrDefault(u => u.Name == username);
            var userPassword = new Password{Hash = hash, UserId = user.Id, Salt = salt};
            await _context.Passwords.AddAsync(userPassword);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
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
        private static int saltsize = 20;
        private static byte[] CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[saltsize];
            rng.GetBytes(buff);
            return buff;
        }
        
        private static byte[] GenerateSaltedHash(string plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            var plainTextWithSaltBytes =
                new byte[plainText.Length + salt.Length];

            for (var i = 0; i < plainText.Length; i++) 
                plainTextWithSaltBytes[i] = (byte) plainText[i];
            for (var i = 0; i < salt.Length; i++) 
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
