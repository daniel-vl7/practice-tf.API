using Swashbuckle.AspNetCore.Annotations;

namespace practice_tf.API.Inventory.Resources;

/// <summary>
/// author
/// </summary>
public class ProductResource
{
    [SwaggerSchema("Product Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Product Brand")]
    public string Brand { get; set; }
    [SwaggerSchema("Product Model")]
    public string Model { get; set; }
    [SwaggerSchema("Product Status Description")] 
    public string StatusDescripction { get; set; }
}