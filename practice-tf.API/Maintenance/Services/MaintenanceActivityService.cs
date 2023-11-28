using practice_tf.API.Inventory.Domain.Repositories;
using practice_tf.API.Maintenance.Domain.Model;
using practice_tf.API.Maintenance.Domain.Repositories;
using practice_tf.API.Maintenance.Domain.Services;
using practice_tf.API.Maintenance.Domain.Services.Communication;

namespace practice_tf.API.Maintenance.Services;

public class MaintenanceActivityService :IMaintenanceActivityService
{
    private readonly IMaintenanceActivityRepository _maintenanceActivityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public MaintenanceActivityService(IMaintenanceActivityRepository maintenanceActivityRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _maintenanceActivityRepository = maintenanceActivityRepository;
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<MaintenanceActivity>> ListAsync()
    {
        return await _maintenanceActivityRepository.ListAsync();
    }

    public async Task<IEnumerable<MaintenanceActivity>> ListBySerialNumberAsync(string serialNumber)
    {
        return await _maintenanceActivityRepository.FindBySerialNumberAsync(serialNumber);
    }

    public async Task<MaintenanceActivityResponse> SaveAsync(MaintenanceActivity maintenanceActivity)
    {
        //validate product serial number
        
        var existingProductSerialNumber = await _productRepository.FindBySerialNumberAsync(maintenanceActivity.ProductSerialNumber);

        if (existingProductSerialNumber ==null)
        {
            return new MaintenanceActivityResponse("Invalid product serial number");
        }
        
        try
        {
            await _maintenanceActivityRepository.AddAsync(maintenanceActivity);
            await _unitOfWork.CompleteAsync();
            return new MaintenanceActivityResponse(maintenanceActivity);
        }
        catch (Exception e)
        {
            return new MaintenanceActivityResponse($"An error occurred while saving the maintenance-activity: {e.Message}");
        }
    }
}