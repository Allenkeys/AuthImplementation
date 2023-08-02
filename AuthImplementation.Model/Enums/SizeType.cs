namespace AuthImplementation.Model.Enums;

public enum SizeType
{
    Small = 1,
    Medium,
    Large
}

public static class SizeTypeExtension
{
    public static string? ToStringValue(this SizeType userType)
    {
        return userType switch
        {
            SizeType.Small => "Small",
            SizeType.Medium => "Medium",
            SizeType.Large => "Large",
            _ => null,
        };
    }
}