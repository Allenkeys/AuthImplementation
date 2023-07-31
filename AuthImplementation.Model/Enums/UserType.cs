namespace AuthImplementation.Model.Enums;

public enum UserType
{
    Admin = 1,
    BackOffice,
    FrontOffice
}

public static class UserTypeExtension
{
    public static string? ToStringValue(this UserType userType)
    {
        return userType switch
        {
            UserType.Admin => "Admin",
            UserType.BackOffice => "BackOffice",
            UserType.FrontOffice => "FrontOffice",
            _ => null,
        };
    }
}
