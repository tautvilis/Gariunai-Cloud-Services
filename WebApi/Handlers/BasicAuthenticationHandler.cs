using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private readonly WebApiContext _context;
        
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

            var hashedAuthorizationPassword = GenerateSaltedHash(password, dbPassword.Salt);

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