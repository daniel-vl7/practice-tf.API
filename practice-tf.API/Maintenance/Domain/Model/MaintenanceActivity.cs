using practice_tf.API.Inventory.Domain.Model;

namespace practice_tf.API.Maintenance.Domain.Model;

public class MaintenanceActivity
{
    public int Id { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public int ActivityResult { get; set; } 
    
    //relationships
    public string ProductSerialNumber { get; set; }
    public Product Product { get; set; }
}