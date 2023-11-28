using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using practice_tf.API.Maintenance.Domain.Model;
using practice_tf.API.Maintenance.Domain.Services;
using practice_tf.API.Maintenance.Resources;
using practice_tf.API.Shared.Extensions;

namespace practice_tf.API.Maintenance.Controller;

[ApiController]
[Route("api/v1/maintenance-activities")]
public class MaintenanceActivitiesController: ControllerBase
{
    private readonly IMaintenanceActivityService _maintenanceActivityService;
    private readonly IMapper _mapper;

    public MaintenanceActivitiesController(IMaintenanceActivityService maintenanceActivityService, IMapper mapper)
    {
        _maintenanceActivityService = maintenanceActivityService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveMaintenanceActivityResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var maintenanceActivity = _mapper.Map<SaveMaintenanceActivityResource, MaintenanceActivity>(resource);
        var result = await _maintenanceActivityService.SaveAsync(maintenanceActivity);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var maintenanceActivityResource = _mapper.Map<MaintenanceActivity, MaintenanceActivityResource>(result.Resource);
        
        return Ok(maintenanceActivityResource);
    }
}