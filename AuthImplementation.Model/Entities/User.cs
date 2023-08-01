using AuthImplementation.Model.Enums;
using Microsoft.AspNetCore.Identity;

namespace AuthImplementation.Model.Entities
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public UserType UserTypeId { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
