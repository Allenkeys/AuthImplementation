using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthImplementation.Model.Dtos.Response;
using AuthImplementation.Model.Entities;

namespace AuthImplementation.Services.JWT
{
    public interface IJwtAuthenticate
    {
        Task<JwtToken> GenerateTokenAsync(User user, string expiration = null, IList<Claim> claims = null);

    }
}
