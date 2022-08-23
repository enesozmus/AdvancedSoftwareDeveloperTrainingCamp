using Application.Dynamic;
using Application.IRepositories;
using Application.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
     protected readonly TrainingCampDbContext _context;

     public ReadRepository(TrainingCampDbContext context)
          => _context = context ?? throw new ArgumentNullException(nameof(context));

     #region IRepository(Tables)

     public virtual IQueryable<T> Table => _context.Set<T>();
     public virtual IQueryable<T> TableNoTracking => _context.Set<T>().AsNoTracking();

     #endregion

     #region Select

     public async Task<IReadOnlyList<T>> GetAllAsync() => await TableNoTracking.ToListAsync();

     public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) => await TableNoTracking.Where(predicate).ToListAsync();

     public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
     {
          IQueryable<T> query = Table;

          if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

          if (predicate != null) query = query.Where(predicate);

          return await query.AsNoTracking().FirstOrDefaultAsync();
     }
     public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
     {
          IQueryable<T> query = TableNoTracking;

          if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

          if (predicate != null) query = query.Where(predicate);

          return await query.AsNoTracking().ToListAsync();
     }

     public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                       string includeString = null, bool disableTracking = true)
     {
          IQueryable<T> query = TableNoTracking;
          if (disableTracking) query = query.AsNoTracking();

          if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

          if (predicate != null) query = query.Where(predicate);

          if (orderBy != null)
               return await orderBy(query).ToListAsync();
          return await query.ToListAsync();
     }

     public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
     {
          IQueryable<T> query = TableNoTracking;
          if (disableTracking) query = query.AsNoTracking();

          if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

          if (predicate != null) query = query.Where(predicate);

          if (orderBy != null)
               return await orderBy(query).ToListAsync();
          return await query.ToListAsync();
     }

     public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

     public virtual async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids) => await _context.Set<IEnumerable<T>>().FindAsync(ids);

     public virtual async Task<int> CountAsync() => await _context.Set<T>().CountAsync();

     public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null) => await _context.Set<T>().CountAsync(predicate);

     public async Task<T> GetForMultipleKeys(params object[] keyValues) => await _context.Set<T>().FindAsync(keyValues);

     #endregion

     #region Then

     public async Task<IPaginate<T>> GetListAsPaginateAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
     {
          IQueryable<T> queryable = Table;
          if (!enableTracking) queryable = queryable.AsNoTracking();
          if (include != null) queryable = include(queryable);
          if (predicate != null) queryable = queryable.Where(predicate);
          if (orderBy != null)
               return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
          return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
     }

     public async Task<IPaginate<T>> GetListAsPaginateByDynamicAsync(Dynamic dynamic, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
     {
          IQueryable<T> queryable = Table.AsQueryable().ToDynamic(dynamic);
          if (!enableTracking) queryable = queryable.AsNoTracking();
          if (include != null) queryable = include(queryable);
          return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
     }

     #endregion
}
