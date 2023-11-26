using Microsoft.EntityFrameworkCore;
using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Inventory.Domain.Repositories;
using practice_tf.API.Shared.Persistence.Contexts;
using practice_tf.API.Shared.Persistence.Repositories;

namespace practice_tf.API.Inventory.Persistence.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async  Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindByIdAsync(int productId)
    {
        return (await _context.Products.FirstOrDefaultAsync(p => p.Id==productId))!;
    }

    public async Task<Product> FindBySerialNumberAsync(string serialNumber)
    {
        return (await _context.Products.FirstOrDefaultAsync(p => p.SerialNumber==serialNumber))!;
    }
}