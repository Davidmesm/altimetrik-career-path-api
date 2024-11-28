using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerPathCore.Domain.Entities
{
    public class UserSoftSkill
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(UserProfile))]
        public Guid UserProfileId { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(SkillLevel))]
        public Guid SkillLevelId { get; set; }
        public bool IsValidated { get; set; }
        [ForeignKey(nameof(Validation))]
        public Guid? ValidtionId { get; set; }

        public UserProfile UserProfile { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public Validation Validation { get; set; }
    }
}
