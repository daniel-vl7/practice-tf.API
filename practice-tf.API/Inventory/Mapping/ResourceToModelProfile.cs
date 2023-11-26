using AutoMapper;
using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Inventory.Resources;

namespace practice_tf.API.Inventory.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProductResource, Product>();
    }
}