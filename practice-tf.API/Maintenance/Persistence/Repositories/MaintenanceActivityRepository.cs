using Microsoft.EntityFrameworkCore;
using practice_tf.API.Maintenance.Domain.Model;
using practice_tf.API.Maintenance.Domain.Repositories;
using practice_tf.API.Shared.Persistence.Contexts;
using practice_tf.API.Shared.Persistence.Repositories;

namespace practice_tf.API.Maintenance.Persistence.Repositories;

public class MaintenanceActivityRepository : BaseRepository, IMaintenanceActivityRepository
{
    public MaintenanceActivityRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<MaintenanceActivity>> ListAsync()
    {
        return await _context.MaintenanceActivities.ToListAsync();
    }

    public async Task AddAsync(MaintenanceActivity maintenanceActivity)
    {
        await _context.MaintenanceActivities.AddAsync(maintenanceActivity);
    }

    public async Task<IEnumerable<MaintenanceActivity>> FindBySerialNumberAsync(string serialNumber)
    {
        return await _context.MaintenanceActivities
            .Where(p => p.ProductSerialNumber == serialNumber)
            .ToListAsync();
    }

    
}