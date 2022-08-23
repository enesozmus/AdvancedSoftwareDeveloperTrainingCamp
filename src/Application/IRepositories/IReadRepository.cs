using Application.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.IRepositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
     #region Select

     Task<IReadOnlyList<T>> GetAllAsync();

     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null);
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                          params Expression<Func<T, object>>[] includes);
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          string includeString = null,
                                          bool disableTracking = true);
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                         List<Expression<Func<T, object>>> includes = null,
                                         bool disableTracking = true);

     Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null,
                                        params Expression<Func<T, object>>[] includes);

     Task<T> GetByIdAsync(int id);
     Task<T> GetForMultipleKeys(params object[] keyValues);
     Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids);
     Task<int> CountAsync();
     Task<int> CountAsync(Expression<Func<T, bool>> predicate);

     #endregion

     #region Then

     //Task<IPaginate<T>> GetAllAsPaginateAsync(Expression<Func<T, bool>>? predicate = null);

     Task<IPaginate<T>> GetListAsPaginateAsync(Expression<Func<T, bool>>? predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                     Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                     int index = 0, int size = 10, bool enableTracking = true,
                                     CancellationToken cancellationToken = default);

     Task<IPaginate<T>> GetListAsPaginateByDynamicAsync(Dynamic.Dynamic dynamic,
                                              Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                              int index = 0, int size = 10, bool enableTracking = true,
                                              CancellationToken cancellationToken = default);

     #endregion
}
