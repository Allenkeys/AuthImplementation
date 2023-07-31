using AuthImplementation.Services.Interfaces;

namespace AuthImplementation.Services.Implementations;

public class AuthServices : IAuthServices
{
    public Task<string> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<string> SignUpAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}
