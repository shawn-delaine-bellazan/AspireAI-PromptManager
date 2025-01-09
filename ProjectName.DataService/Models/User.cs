using System.ComponentModel.DataAnnotations;

namespace ProjectName.DataService.Models
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string PasswordHash { get; set; } // Store hashed password

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties for prompts and prompt designs
        public ICollection<Prompt> Prompts { get; set; }
        public ICollection<PromptDesign> PromptDesigns { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
