using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Services.Interfaces;

namespace AuthImplementation.Services.Implementations;

public class AuthServices : IAuthServices
{
    public Task<string> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<string> SignUpAsync(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }
}
