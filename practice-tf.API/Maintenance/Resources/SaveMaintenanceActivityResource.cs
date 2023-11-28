using System.ComponentModel.DataAnnotations;

namespace practice_tf.API.Maintenance.Resources;

public class SaveMaintenanceActivityResource
{
    [Required]
    public string Summary { get; set; }
    
    public string Description { get; set; }
    
    [Required]
    [Range(0,1)]
    public int ActivityResult { get; set; }
    
    [Required]
    public string ProductSerialNumber { get; set; }
}