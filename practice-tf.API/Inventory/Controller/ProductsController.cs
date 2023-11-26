using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Inventory.Domain.Services;
using practice_tf.API.Inventory.Resources;
using practice_tf.API.Shared.Extensions;

namespace practice_tf.API.Inventory.Controller;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    
    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        var products = await _productService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
    {
        if (!ModelState.IsValid){
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var product = _mapper.Map<SaveProductResource, Product>(resource);
        var result = await _productService.SaveAsync(product);

        if (!result.Success){
            return BadRequest(result.Message);
        }
        
        var productResource = _mapper.Map<Product, ProductResource>(result.Resource);

        return Ok(productResource);
    }
}