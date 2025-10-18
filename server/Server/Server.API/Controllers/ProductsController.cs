using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Product.Query;

namespace Server.API.Controllers;

public class ProductsController:BasicController
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductById(string productId)
    {
        var query = new GetProductByIdQuery(productId);
        var product = await _sender.Send(query);
        return product==null? NotFound(): Ok(product);
    }
}