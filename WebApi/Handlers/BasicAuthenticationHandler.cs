using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApi.Models;

namespace WebApi.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private Salter _salter;
        private readonly WebApiContext _context;

        public delegate byte[] Hashing(string str, byte[] salt);
        private SaltAgorithm _saltAgorithm;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder,
            ISystemClock clock, 
            WebApiContext context) 
            : base(options, logger, encoder, clock)
        {
            _context = context;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header was not found");
            }
            
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            var credentials = Encoding.UTF8.GetString(bytes).Split(":");

            var username = credentials[0];
            var password = credentials[1];

            var user = _context.Users.FirstOrDefault(u => u.Name == username);
            if (user == null)
            {
                return AuthenticateResult.Fail("User not found");
            }

            var dbPassword = _context.Passwords.FirstOrDefault(p => p.UserId == user.Id);

            if (dbPassword == null)
            {
                return AuthenticateResult.Fail("Internal authentication error");
            }
            
            if(_salter == null)
                _salter = new Salter();
            if(_saltAgorithm == null)
                _saltAgorithm = new SaltAgorithm();
            Hashing hashdelegate = _saltAgorithm.Hash;
            
            var hashedAuthorizationPassword = _salter.GenerateSaltedHash(password, dbPassword.Salt, hashdelegate);

            if (dbPassword.Hash.SequenceEqual(hashedAuthorizationPassword))
            {
                var claims = new[] {new Claim(ClaimTypes.Name, user.Id.ToString())};
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Wrong password");

        }
    }
}