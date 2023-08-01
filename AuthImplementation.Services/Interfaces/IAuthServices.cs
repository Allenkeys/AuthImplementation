using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Model.Dtos.Response;
using Microsoft.AspNetCore.Identity;

namespace AuthImplementation.Services.Interfaces;

public interface IAuthServices
{
    Task<IdentityResult> SignUpAsync(CreateUserRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
}
