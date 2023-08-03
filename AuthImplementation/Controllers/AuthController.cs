using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Model.Dtos.Response;
using AuthImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

    [HttpPost("", Name = "sign-up")]
    [SwaggerOperation(Summary = "Register user")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "returns a success message on user creation", Type = typeof(IdentityResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "You did something wrong!", Type = typeof(IdentityResult))]
    public async Task<IActionResult> SignUp(CreateUserRequest request)
    {
        var response = await _auth.SignUpAsync(request);
        return Ok(response);
    }

    [HttpPost("login", Name = "login-a-user")]
    [SwaggerOperation(Summary = "Login with credentials")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "returns user token, Id, name and role", Type = typeof(AuthResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "You did something wrong!", Type = typeof(BadRequestResult))]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _auth.LoginAsync(request);
        if (response == null)
            return BadRequest();
        return Ok(response);
    }
}