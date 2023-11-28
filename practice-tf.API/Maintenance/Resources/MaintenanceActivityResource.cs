using practice_tf.API.Inventory.Resources;

namespace practice_tf.API.Maintenance.Resources;

public class MaintenanceActivityResource
{
    public int Id { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public int ActivityResult { get; set; }
    public ProductResource Product { get; set; }
}