using System.Linq.Expressions;

namespace Films.Database.Services;

public class DbService : IDbService
{
    private readonly FilmContext _db;
    private readonly IMapper _mapper;

    public DbService(FilmContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<TDto>> GetAsync<TEntity, TDto>()
    where TEntity : class, IEntity
    where TDto : class
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }

    public async Task<TEntity?> SingleAsync<TEntity>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity => await _db.Set<TEntity>().SingleOrDefaultAsync(expression);

    public async Task<List<TDto>> SingleAsync<TEntity, TDto>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class;
    {
        var entity = await SingleAsync(expression);
        return _mapper.Map<List<TDto>>(entity);
    }

    //Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
    //    where TEntity : class, IEntity
    //    where TDto : class;

    //Task<bool> SaveChangesAsync();

}

    //void Add<TEntity, TDto>(TDto obj)
    //{

    //}
    //void Update<TEntity, TDto>(TDto obj)
    //{

    //}
    //void UpdateFilm(FilmDTO film);
    //void GetFilms();
    //void GetFilm(int id);
    //void DeleteFilm(int id);
