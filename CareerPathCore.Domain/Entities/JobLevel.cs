using System.ComponentModel.DataAnnotations;

namespace CareerPathCore.Domain.Entities
{
    public class JobLevel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
