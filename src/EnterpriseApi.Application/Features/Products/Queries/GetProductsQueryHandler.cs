using EnterpriseApi.Application.Features.Products.DTOs;
using EnterpriseApi.Application.Interfaces;

namespace EnterpriseApi.Application.Features.Products.Queries;

public sealed class GetProductsQueryHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IReadOnlyList<ProductDto>> HandleAsync(
        GetProductsQuery query,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);

        var products = await _productRepository.GetAllAsync(cancellationToken);

        return products
            .Select(product => new ProductDto(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Category,
                product.CreatedUtc))
            .ToArray();
    }
}