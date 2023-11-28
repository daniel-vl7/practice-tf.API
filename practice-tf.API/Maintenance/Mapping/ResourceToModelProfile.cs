using AutoMapper;
using practice_tf.API.Maintenance.Domain.Model;
using practice_tf.API.Maintenance.Resources;

namespace practice_tf.API.Maintenance.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveMaintenanceActivityResource, MaintenanceActivity>();
    }
}