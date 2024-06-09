namespace SocialNetwork.API.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    // CRUD generico 
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}