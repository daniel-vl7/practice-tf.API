using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Shared.Domain.Services.Communication;

namespace practice_tf.API.Inventory.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
    }

    public ProductResponse(Product resource) : base(resource)
    {
    }
}