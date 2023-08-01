using System.ComponentModel.DataAnnotations;
using AuthImplementation.Model.Enums;

namespace AuthImplementation.Model.Dtos.Request;

public class CreateUserRequest
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    public string? Middlename { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public UserType UserTypeId { get; set; }
}
