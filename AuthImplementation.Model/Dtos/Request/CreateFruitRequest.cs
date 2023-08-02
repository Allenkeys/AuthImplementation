using AuthImplementation.Model.Enums;

namespace AuthImplementation.Model.Dtos.Request;

public class CreateFruitRequest
{
    public string Name { get; set; }
    public string Colour { get; set; }
    public SizeType SizeTypeId { get; set; }
}
