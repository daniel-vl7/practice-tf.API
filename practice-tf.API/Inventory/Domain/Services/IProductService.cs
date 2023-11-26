using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Inventory.Domain.Services.Communication;

namespace practice_tf.API.Inventory.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<ProductResponse> SaveAsync(Product product);
}