using EnterpriseApi.Domain.Entities;

namespace EnterpriseApi.Domain.Tests.Entities;

public sealed class ProductTests
{
    [Fact]
    public void Constructor_ShouldSetProductProperties()
    {
        var product = new Product(
            "Developer Laptop",
            "Laptop for software engineers.",
            1499.00m,
            "Computers");

        Assert.Equal("Developer Laptop", product.Name);
        Assert.Equal("Laptop for software engineers.", product.Description);
        Assert.Equal(1499.00m, product.Price);
        Assert.Equal("Computers", product.Category);
        Assert.True(product.CreatedUtc <= DateTime.UtcNow);
    }

    [Fact]
    public void Id_ShouldSupportInitialization()
    {
        var product = new Product(
            "Monitor",
            "Development monitor.",
            599.00m,
            "Displays")
        {
            Id = 10
        };

        Assert.Equal(10, product.Id);
    }
}