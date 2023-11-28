using System.Text.Json.Serialization;
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
    public string? Brand { get; set; }
    [SwaggerSchema("Product Model")]
    public string? Model { get; set; }
    
    [JsonIgnore]
    public int Status { get; set; }
    [SwaggerSchema("Product Status Description")]
    public string StatusDescription => Status == 1 ? "OPERATIONAL" : "UNOPERATIONAL";
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}