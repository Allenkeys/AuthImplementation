using AuthImplementation.Model.Dtos.Request;

namespace AuthImplementation.Services.Interfaces;

public interface IAuthServices
{
    Task<string> SignUpAsync(CreateUserRequest request);
    Task<string> LoginAsync(LoginRequest request);
}
