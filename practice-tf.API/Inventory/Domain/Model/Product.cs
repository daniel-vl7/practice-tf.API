using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using practice_tf.API.Maintenance.Domain.Model;

namespace practice_tf.API.Inventory.Domain.Model;

public class Product
{
    public int Id { get; set; }
    
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
    
    public MaintenanceActivity MaintenanceActivity { get; set; }
}