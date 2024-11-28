using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerPathCore.Domain.Entities
{
    public class UserProfile
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        [ForeignKey(nameof(EducationLevel))]
        public Guid EducationLevelId { get; set; }
        public string FieldOfStudy { get; set; }

        [ForeignKey(nameof(CurrentJobRole))]
        public Guid CurrentJobRoleId { get; set; }
        [ForeignKey(nameof(FutureJobRole))]
        public Guid FutureJobRoleId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public User User { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public JobRole CurrentJobRole { get; set; }
        public JobRole FutureJobRole { get; set;}
        public IEnumerable<UserHardSkill> HardSkills { get; set; }
        public IEnumerable<UserSoftSkill> SoftSkills { get; set; }
    }
}
