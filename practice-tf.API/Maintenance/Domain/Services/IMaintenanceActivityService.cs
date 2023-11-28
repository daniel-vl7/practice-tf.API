using practice_tf.API.Maintenance.Domain.Model;
using practice_tf.API.Maintenance.Domain.Services.Communication;

namespace practice_tf.API.Maintenance.Domain.Services;

public interface IMaintenanceActivityService
{
    Task<IEnumerable<MaintenanceActivity>> ListAsync();
    Task<IEnumerable<MaintenanceActivity>> ListBySerialNumberAsync(string serialNumber);
    Task<MaintenanceActivityResponse> SaveAsync(MaintenanceActivity maintenanceActivity);
}