using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthImplementation.Model.Dtos.Response;
using AuthImplementation.Model.Entities;
using AuthImplementation.Model.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthImplementation.Services.JWT
{
    public class JwtAuthenticate : IJwtAuthenticate
    {
        private readonly IConfiguration _configuration;
        public JwtAuthenticate(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<JwtToken> GenerateTokenAsync(User user, string expiration = null, IList<Claim> claims = null)
        {

        }

        private async Task<IList<Claim>> GetClaimsAsync(User user, IList<Claim> claims = null)
        {
            IdentityOptions options = new();
            var claimsBuilder = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(options.ClaimsIdentity.UserIdClaimType, user.Id),
                new Claim(options.ClaimsIdentity.UserNameClaimType, user.UserName),
                new Claim(ClaimTypes.Role, user.UserTypeId.ToStringValue())
            };
            if (claims != null)
                claimsBuilder.AddRange(claims);

            return claimsBuilder;
        }

        private async Task<SigningCredentials> GetSigningCredentialsAsync()
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["key"]));
            return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        }

        private async Task<JwtSecurityToken> GenerateSecurityTokenAsync(SigningCredentials credentials, IList<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");

            return new JwtSecurityToken
                (
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(double.Parse(jwtSettings["Expires"])),
                    signingCredentials: credentials
                );
        }
    }
}
