using AutoMapper;
using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Inventory.Resources;

namespace practice_tf.API.Inventory.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Product, ProductResource>();
    }
}