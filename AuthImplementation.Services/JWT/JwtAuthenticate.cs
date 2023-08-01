using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthImplementation.Model.Dtos.Response;
using AuthImplementation.Model.Entities;
using AuthImplementation.Model.Enums;
using Microsoft.AspNetCore.Identity;

namespace AuthImplementation.Services.JWT
{
    public class JwtAuthenticate : IJwtAuthenticate
    {
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
    }
}
