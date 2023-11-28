using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Inventory.Domain.Services;
using practice_tf.API.Inventory.Resources;
using practice_tf.API.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace practice_tf.API.Inventory.Controller
{
    /// <summary>
    /// Controller responsible for handling HTTP requests related to products.
    /// </summary>
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Read and create products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">The service for handling product-related business logic.</param>
        /// <param name="mapper">The mapper for mapping between different data representations.</param>
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of all products asynchronously.
        /// </summary>
        /// <returns>An asynchronous operation that returns a list of product resources.</returns>
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        /// <summary>
        /// Creates a new product asynchronously.
        /// </summary>
        /// <param name="resource">The resource containing information for creating a new product.</param>
        /// <returns>
        /// An asynchronous operation that returns an HTTP result indicating success or failure,
        /// along with the created product resource if successful.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            // Validate the incoming model state.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            // Map the resource to a product entity.
            var product = _mapper.Map<SaveProductResource, Product>(resource);

            // Save the product asynchronously.
            var result = await _productService.SaveAsync(product);

            // Handle the result and return an appropriate HTTP response.
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            // Map the created product to a resource and return it.
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }
    }
}
