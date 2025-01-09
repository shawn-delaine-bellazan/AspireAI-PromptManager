using System.ComponentModel.DataAnnotations;

namespace ProjectName.DataService.Models
{
    public class Prompt : BaseEntity
    {
        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Reference to the design this prompt might belong to
        public int? PromptDesignId { get; set; }
        public PromptDesign PromptDesign { get; set; }

        // User who created or is associated with this prompt
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
