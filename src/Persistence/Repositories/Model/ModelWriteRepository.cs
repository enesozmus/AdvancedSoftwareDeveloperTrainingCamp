using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModelWriteRepository : WriteRepository<Model>, IModelWriteRepository
{
     public ModelWriteRepository(AdvancedSoftwareDeveloperTrainingCampDbContext context) : base(context) { }
}
