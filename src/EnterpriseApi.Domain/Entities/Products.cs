namespace EnterpriseApi.Domain.Entities;

public sealed class Product
{
    public int Id { get; init; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public string Category { get; private set; }

    public DateTime CreatedUtc { get; private set; }

    public Product(
        string name,
        string description,
        decimal price,
        string category)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        CreatedUtc = DateTime.UtcNow;
    }
}