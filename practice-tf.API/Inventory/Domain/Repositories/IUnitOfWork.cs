namespace practice_tf.API.Inventory.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}