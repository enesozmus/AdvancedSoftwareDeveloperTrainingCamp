using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
{
     public BrandReadRepository(TrainingCampDbContext context) : base(context) { }
}
