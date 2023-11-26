using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practice_tf.API.Inventory.Resources;

public class SaveProductResource
{
    [Required]
    public string? Brand { get; set; }
    
    [Required]
    public string? Model { get; set; }
    
    [Required]
    public string? SerialNumber { get; set; }
    
    [Required]
    [Range(1,2)]
    public int Status { get; set; }
    
    [NotMapped]
    public string StatusDescription => Status == 1 ? "OPERATIONAL" : "UNOPERATIONAL";
}