using System.Linq.Expressions;

namespace Films.Database.Interfaces;

public interface IDbService
{
    Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class, IEntity
        where TDto : class;

    Task<List<TDto>> SingleAsync<TEntity, TDto>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class;
    //Task<TEntity?> SingleAsync<TEntity>(
    //    Expression<Func<TEntity, bool>> expression)
    //    where TEntity : class, IEntity => await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
}
