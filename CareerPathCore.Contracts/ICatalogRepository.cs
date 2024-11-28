using CareerPathCore.Domain.Entities;

namespace CareerPathCore.Contracts
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<EducationLevel>> GetEducationLevels();
    }
}
