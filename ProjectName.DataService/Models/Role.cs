using System.ComponentModel.DataAnnotations;

namespace ProjectName.DataService.Models
{
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        // Navigation property for many-to-many relationship with users
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
