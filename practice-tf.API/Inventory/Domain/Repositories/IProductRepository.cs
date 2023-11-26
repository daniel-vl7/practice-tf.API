using practice_tf.API.Inventory.Domain.Model;

namespace practice_tf.API.Inventory.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task AddAsync(Product product);
    Task<Product> FindByIdAsync(int productId);
    Task<Product> FindBySerialNumberAsync(string serialNumber);
}