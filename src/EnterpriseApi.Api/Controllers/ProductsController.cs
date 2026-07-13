using EnterpriseApi.Application.Features.Products.DTOs;
using EnterpriseApi.Application.Features.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProductsController : ControllerBase
{
    private readonly GetProductsQueryHandler _handler;
    private readonly GetProductByIdQueryHandler _getByIdHandler;

    public ProductsController(
    GetProductsQueryHandler getAllHandler,
    GetProductByIdQueryHandler getByIdHandler)
    {
        _handler = getAllHandler;
        _getByIdHandler = getByIdHandler;
    }

    [HttpGet]
    [ProducesResponseType<IReadOnlyList<ProductDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll(
        CancellationToken cancellationToken)
    {
        var products = await _handler.HandleAsync(
            new GetProductsQuery(),
            cancellationToken);

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType<ProductDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        var result = await _getByIdHandler.HandleAsync(
            new GetProductByIdQuery(id),
            cancellationToken);

        if (!result.Success)
        {
            return NotFound(new
            {
                error = result.Error
            });
        }

        return Ok(result.Value);
    }
}
