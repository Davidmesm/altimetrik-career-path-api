using System.ComponentModel.DataAnnotations;

namespace CareerPathCore.Domain.Entities
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}