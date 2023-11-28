using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace practice_tf.API.Inventory.Resources;

/// <summary>
/// author
/// </summary>

[SwaggerSchema(Required = new []{"Course"})]
public class SaveProductResource
{
    
    [SwaggerSchema("Product Brand")]
    [Required]
    public string? Brand { get; set; }
    
    [SwaggerSchema("Product Model")]
    [Required]
    public string? Model { get; set; }
    
    [SwaggerSchema("Product Serial Number")]
    [Required]
    public string? SerialNumber { get; set; }
    
    [SwaggerSchema("Product - Status")]
    [Required]
    [Range(1,2,ErrorMessage = "value between 1 or 2")]
    public int Status { get; set; }
    
    [NotMapped]
    public string StatusDescription => Status == 1 ? "OPERATIONAL" : "UNOPERATIONAL";
}