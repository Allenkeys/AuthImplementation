using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthImplementation.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _auth;

    public AuthController(IAuthServices auth)
    {
        _auth = auth;
    }

    [HttpPost("Sign-Up", Name = "sign-up")]
    [SwaggerOperation(Summary = "Register user")]
    public async Task<IActionResult> SignUp(CreateUserRequest request)
    {
        var response = await _auth.SignUpAsync(request);
        return Ok(response);
    }

    [HttpPost("Login-A-User", Name = "login-a-user")]
    [SwaggerOperation(Summary = "Login with user credentials")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _auth.LoginAsync(request);
        return Ok(response);
    }
}