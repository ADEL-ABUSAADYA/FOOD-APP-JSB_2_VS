using System.Linq.Expressions;

namespace FOOD_APP_JSB_2.Data.Repositories;

public interface IRepository<Entity>
{
    void Add(Entity entity);
    IQueryable<Entity> GetAll();
    Task<Entity> GetByIDAsync(int id);
    Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate);
    void SaveChanges();
}