using System.ComponentModel.DataAnnotations;

namespace CareerPathCore.Domain.Entities
{
    public class Validation
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ValidationTypeId { get; set; }
    }
}
