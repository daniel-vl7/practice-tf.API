using AutoMapper;
using practice_tf.API.Maintenance.Domain.Model;
using practice_tf.API.Maintenance.Resources;

namespace practice_tf.API.Maintenance.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<MaintenanceActivity, MaintenanceActivityResource>();
    }
}