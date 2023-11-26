using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Inventory.Domain.Repositories;
using practice_tf.API.Inventory.Domain.Services;
using practice_tf.API.Inventory.Domain.Services.Communication;

namespace practice_tf.API.Inventory.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        var existingProductWithSerialNumber = await _productRepository.FindBySerialNumberAsync(product.SerialNumber!);

        if (existingProductWithSerialNumber!=null){
            return new ProductResponse("Product with same serial number already exists");
        }

        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            return new ProductResponse("An error occurred while saving the product: " + e.Message);
        }
    }
}