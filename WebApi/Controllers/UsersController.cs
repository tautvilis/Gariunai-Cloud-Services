using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Handlers;
using WebApi.Models;
using WebApi.Models.DataTransferObjects;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly WebApiContext _context;
        private readonly ISalter _salter;
        private readonly IMapper _mapper;
        private SaltAgorithm _saltAgorithm;

        public UsersController(WebApiContext context, ISalter salter, IMapper mapper)
        {
            _context = context;
            _salter = salter;
            _mapper = mapper;
        }
        
        // GET: api/Users/Authorize
        [HttpGet("Authorize")]
        [Authorize]
        public async Task<ActionResult<UserDto>> CheckAuthorization()
        {
            var user = _context.Users.FindAsync(AuthenticatedUserId());
            return _mapper.Map<UserDto>(await user);
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return _mapper.Map<List<UserDto>>(await _context.Users.ToListAsync());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return _mapper.Map<UserDto>(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] UserDto userDto, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(userDto.Name))
                {
                    throw new ArgumentNullException(nameof(userDto.Name));
                }
                
                if (string.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException(nameof(password), "cannot be null or empty");
                }
                if (await CheckIfUsernameTaken(userDto.Name))
                {
                    return StatusCode(406);
                }
                
                var salt = _salter.CreateSalt();
                _saltAgorithm ??= new SaltAgorithm();
                BasicAuthenticationHandler.Hashing hashdelegate = _saltAgorithm.Hash;
                var hash = _salter.GenerateSaltedHash(password, salt,hashdelegate);

                var user = _mapper.Map<User>(userDto);
                
                await _context.Users.AddAsync(_mapper.Map<User>(user));
                await _context.SaveChangesAsync();
                
                var userPassword = new Password {Hash = hash, UserId = user.Id, Salt = salt};
                
                await _context.Passwords.AddAsync(userPassword);
                await _context.SaveChangesAsync();
                
                return CreatedAtAction("GetUser", new {id = user.Id}, _mapper.Map<UserDto>(user));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest();
            }
            
        }
        private async Task<bool> CheckIfUsernameTaken(string username)
        {
            return (await _context.Users.CountAsync(user => user.Name == username)) > 0;
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            if (id != AuthenticatedUserId())
            {
                return Unauthorized("You are not this user");
            }

            var user = _mapper.Map<User>(userDto);
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
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            
            if (user == null)
            {
                return NotFound("User not found");
            }

            if (id != AuthenticatedUserId())
            {
                return Unauthorized("You are not this user");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        
        private int AuthenticatedUserId()
        {
            return int.Parse(HttpContext.User.Identity.Name ?? "-1");
        }
        
    }
}
