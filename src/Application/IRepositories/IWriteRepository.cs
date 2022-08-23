using Domain.Entities;

namespace Application.IRepositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
     #region Insert

     Task<T> AddAsync(T entity);
     Task AddRangeAsync(IEnumerable<T> entities);

     #endregion

     #region Update

     //Task UpdateAsync(T entity);
     //Task UpdateRangeAsync(IEnumerable<T> entities);

     void Update(T entity);
     void UpdateRange(IEnumerable<T> entities);

     #endregion

     #region Delete

     //Task RemoveAsync(T entity);
     //Task RemoveRangeAsync(IEnumerable<T> entities);
     void Remove(T entity);
     void RemoveRange(IEnumerable<T> entities);

     #endregion

     #region SaveAsync

     Task<int> SaveAsync();

     #endregion
}
