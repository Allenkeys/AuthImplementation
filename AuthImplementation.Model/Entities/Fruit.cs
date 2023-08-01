using AuthImplementation.Model.Enums;

namespace AuthImplementation.Model.Entities;

public class Fruit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Colour { get; set; }
    public SizeType SizeTypeId { get; set; }
}
