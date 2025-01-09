using System.ComponentModel.DataAnnotations;

namespace ProjectName.DataService.Models
{
    public class PromptDesign : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Collection of prompts that belong to this design
        public ICollection<Prompt> Prompts { get; set; }

        // User who created or is associated with this design
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
