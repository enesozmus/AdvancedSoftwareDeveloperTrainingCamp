﻿using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
{
     public BrandWriteRepository(AdvancedSoftwareDeveloperTrainingCampDbContext context) : base(context) { }
}
