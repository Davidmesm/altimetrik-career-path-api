using System.ComponentModel.DataAnnotations;

namespace CareerPathCore.Domain.Entities
{
    public class EducationLevel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
