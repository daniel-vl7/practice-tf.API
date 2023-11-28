using Microsoft.EntityFrameworkCore;
using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Inventory.Domain.Repositories;
using practice_tf.API.Shared.Persistence.Contexts;
using practice_tf.API.Shared.Persistence.Repositories;

namespace practice_tf.API.Inventory.Persistence.Repositories
{
    /// <summary>
    /// Repository class for accessing and managing product data in the database.
    /// </summary>
    public class ProductRepository : BaseRepository, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for accessing the data store.</param>
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves a list of all products asynchronously.
        /// </summary>
        /// <returns>An asynchronous operation that returns the list of products.</returns>
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Adds a new product to the database asynchronously.
        /// </summary>
        /// <param name="product">The product to be added.</param>
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        /// <summary>
        /// Finds a product by its unique identifier asynchronously.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <returns>An asynchronous operation that returns the found product or null if not found.</returns>
        public async Task<Product> FindByIdAsync(int productId)
        {
            return (await _context.Products.FirstOrDefaultAsync(p => p.Id == productId))!;
        }

        /// <summary>
        /// Finds a product by its serial number asynchronously.
        /// </summary>
        /// <param name="serialNumber">The serial number of the product.</param>
        /// <returns>An asynchronous operation that returns the found product or null if not found.</returns>
        public async Task<Product> FindBySerialNumberAsync(string serialNumber)
        {
            return (await _context.Products.FirstOrDefaultAsync(p => p.SerialNumber == serialNumber))!;
        }
    }
}
