using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerPathCore.Domain.Entities
{
    public class JobRole
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(JobArea))]
        public Guid JobAreaId { get; set; }
        [ForeignKey(nameof(JobLevel))]
        public Guid JobLevelId { get; set; }

        
        public JobArea JobArea { get; set; }
        public JobLevel JobLevel { get; set; }
    }
}
