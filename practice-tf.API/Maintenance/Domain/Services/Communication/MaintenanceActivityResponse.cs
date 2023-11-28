using practice_tf.API.Maintenance.Domain.Model;
using practice_tf.API.Shared.Domain.Services.Communication;

namespace practice_tf.API.Maintenance.Domain.Services.Communication;

public class MaintenanceActivityResponse: BaseResponse<MaintenanceActivity>
{
    public MaintenanceActivityResponse(string message) : base(message)
    {
    }

    public MaintenanceActivityResponse(MaintenanceActivity resource) : base(resource)
    {
    }
}