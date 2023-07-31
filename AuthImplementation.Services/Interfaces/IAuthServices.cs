namespace AuthImplementation.Services.Interfaces;

public interface IAuthServices
{
    Task<string> SignUpAsync(string username, string password);
    Task<string> LoginAsync(string username, string password);
}
