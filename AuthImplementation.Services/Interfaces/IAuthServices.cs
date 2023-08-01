using AuthImplementation.Model.Dtos.Request;
using Microsoft.AspNetCore.Identity;

namespace AuthImplementation.Services.Interfaces;

public interface IAuthServices
{
    Task<IdentityResult> SignUpAsync(CreateUserRequest request);
    Task<string> LoginAsync(LoginRequest request);
}
