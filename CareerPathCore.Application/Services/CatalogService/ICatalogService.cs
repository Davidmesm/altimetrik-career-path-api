using CareerPathCore.Domain.Entities;

namespace CareerPathCore.Application.Services.CatalogService
{
    public interface ICatalogService
    {
        Task<IEnumerable<EducationLevel>> GetEducationLevels();
    }
}
