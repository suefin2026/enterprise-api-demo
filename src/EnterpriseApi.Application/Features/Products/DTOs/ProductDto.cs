namespace EnterpriseApi.Application.Features.Products.DTOs;

public sealed record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string Category,
    DateTime CreatedUtc);