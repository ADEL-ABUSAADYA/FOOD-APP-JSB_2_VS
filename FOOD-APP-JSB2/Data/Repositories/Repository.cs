using FOOD_APP_JSB_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace FOOD_APP_JSB_2.Data.Repositories;

public class Repository<Entity> : IRepository<Entity> where Entity : BaseModel
{
    Context _context;
    DbSet<Entity> _dbSet;

    public Repository(Context context)
    {
        _context = context;
        _dbSet = _context.Set<Entity>();
    }

    public void Add(Entity entity)
    {
        entity.CreatedDate = DateTime.Now;
        //entity.CreatedBy = userID;

        _dbSet.Add(entity);
    }

    public async Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public IQueryable<Entity> GetAll()
    {
        return _dbSet.Where(x => ! x.Deleted);
    }

    public async Task<Entity> GetByIDAsync(int id)
    {
       var entity = await _dbSet.Where(x => x.ID == id).FirstOrDefaultAsync();
       return entity;
    }


    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
