using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Model.Entities;
using AuthImplementation.Model.Enums;
using AuthImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AuthImplementation.Services.Implementations;

public class AuthServices : IAuthServices
{
    private readonly UserManager<User> _userManager;
    public AuthServices(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public Task<string> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> SignUpAsync(CreateUserRequest request)
    {
        User existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
            throw new InvalidOperationException($"User with email: {request.Email} already exist");

        User user = new()
        {
            Firstname = request.Firstname,
            Middlename = request.Middlename,
            UserName = request.Username,
            Lastname = request.Lastname,
            Email = request.Email,
            UserTypeId = request.UserTypeId,
        };

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new InvalidOperationException($"Failed to create user: {result.Errors.FirstOrDefault()!.Description}");

        await _userManager.AddToRoleAsync(user, request.UserTypeId.ToStringValue());

        return result;
    }
}
