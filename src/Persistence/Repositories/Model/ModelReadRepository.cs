using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModelReadRepository : ReadRepository<Model>, IModelReadRepository
{
     public ModelReadRepository(AdvancedSoftwareDeveloperTrainingCampDbContext context) : base(context) { }
}
