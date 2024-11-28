using CareerPathCore.Contracts;
using CareerPathCore.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPathCore.Application.Services.CatalogService.Implementation
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<IEnumerable<EducationLevel>> GetEducationLevels()
        {
            return await _catalogRepository.GetEducationLevels();
        }
    }
}
