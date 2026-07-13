using EnterpriseApi.Application.Common;
using EnterpriseApi.Application.Features.Products.DTOs;
using EnterpriseApi.Application.Interfaces;

namespace EnterpriseApi.Application.Features.Products.Queries;

public sealed class GetProductByIdQueryHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductDto>> HandleAsync(
        GetProductByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);

        var product = await _productRepository.GetByIdAsync(
            query.Id,
            cancellationToken);

        if (product is null)
        {
            return Result<ProductDto>.Fail(
                $"Product with ID {query.Id} was not found.");
        }

        var dto = new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Category,
            product.CreatedUtc);

        return Result<ProductDto>.Ok(dto);
    }
}