using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Domain.Entities;

namespace EnterpriseApi.Infrastructure.Repositories;

public sealed class InMemoryProductRepository : IProductRepository
{
    private static readonly IReadOnlyList<Product> Products =
    [
        new Product(
            "Enterprise Laptop",
            "Business laptop for engineering teams.",
            1_499.00m,
            "Computers")
        {
            Id = 1
        },

        new Product(
            "Developer Monitor",
            "High-resolution monitor for software development.",
            649.00m,
            "Displays")
        {
            Id = 2
        },

        new Product(
            "Mechanical Keyboard",
            "Professional keyboard designed for daily development.",
            149.00m,
            "Accessories")
        {
            Id = 3
        }
    ];

    public Task<IReadOnlyList<Product>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(Products);
    }

    public Task<Product?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var product = Products.FirstOrDefault(product => product.Id == id);

        return Task.FromResult(product);
    }
}