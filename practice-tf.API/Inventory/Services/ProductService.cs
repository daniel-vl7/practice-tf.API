using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Inventory.Domain.Repositories;
using practice_tf.API.Inventory.Domain.Services;
using practice_tf.API.Inventory.Domain.Services.Communication;

namespace practice_tf.API.Inventory.Services
{
    /// <summary>
    /// Service class responsible for handling business logic related to products.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The repository for accessing product data.</param>
        /// <param name="unitOfWork">The unit of work for managing transactions.</param>
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieves a list of all products asynchronously.
        /// </summary>
        /// <returns>An asynchronous operation that returns the list of products.</returns>
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        /// <summary>
        /// Saves a new product asynchronously and returns a response.
        /// </summary>
        /// <param name="product">The product to be saved.</param>
        /// <returns>An asynchronous operation that returns a <see cref="ProductResponse"/>.</returns>
        public async Task<ProductResponse> SaveAsync(Product product)
        {
            // Check if a product with the same serial number already exists.
            var existingProductWithSerialNumber = await _productRepository.FindBySerialNumberAsync(product.SerialNumber!);

            if (existingProductWithSerialNumber != null)
            {
                return new ProductResponse("Product with the same serial number already exists");
            }

            try
            {
                // Add the new product, complete the unit of work, and return a successful response.
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception e)
            {
                // Return an error response if an exception occurs during the save operation.
                return new ProductResponse("An error occurred while saving the product: " + e.Message);
            }
        }
    }
}
