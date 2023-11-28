using practice_tf.API.Maintenance.Domain.Model;

namespace practice_tf.API.Maintenance.Domain.Repositories;

public interface IMaintenanceActivityRepository
{
    Task<IEnumerable<MaintenanceActivity>> ListAsync();
    Task AddAsync(MaintenanceActivity maintenanceActivity);
    Task<IEnumerable<MaintenanceActivity>> FindBySerialNumberAsync(string serialNumber);
}