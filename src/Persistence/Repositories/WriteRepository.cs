using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{

     #region ctor

     protected readonly TrainingCampDbContext _context;

     public WriteRepository(TrainingCampDbContext context)
          => _context = context ?? throw new ArgumentNullException(nameof(context));

     #endregion

     #region IRepository(Tables)

     public  IQueryable<T> Table => _context.Set<T>();
     public  IQueryable<T> TableNoTracking => _context.Set<T>().AsNoTracking();

     #endregion

     #region Insert

     public async Task<T> AddAsync(T entity)
     {
          await _context.Set<T>().AddAsync(entity);
          return entity;
     }

     public async Task AddRangeAsync(IEnumerable<T> entities)
          => await _context.Set<T>().AddRangeAsync(entities);

     #endregion

     #region Update

     public void Update(T entity)
          => _context.Entry(entity).State = EntityState.Modified;

     public void UpdateRange(IEnumerable<T> entities)
          => _context.Entry(entities).State = EntityState.Modified;

     #endregion

     #region Delete

     public void Remove(T entity)
          => _context.Entry(entity).State = EntityState.Deleted;

     public void RemoveRange(IEnumerable<T> entities)
          => _context.Entry(entities).State = EntityState.Deleted;

     #endregion

     #region Save

     public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

     #endregion
}
