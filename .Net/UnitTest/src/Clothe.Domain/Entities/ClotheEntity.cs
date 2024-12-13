namespace Clothes.Domain.Entities;

public class ClotheEntity : BaseEntity
{
    private ClotheEntity()
    {
    }
    public ClotheEntity(string name, string model, int year, string size, string color)
        : base()
    {
        Name = name;
        Fabric = model;
        Year = year;
        Size = size;
        Color = color;
    }

    public string Name { get; private set; }
    public string Fabric { get; private set; }
    public int Year { get; private set; }
    public string Size { get; private set; }
    public string Color { get; private set; }
}
