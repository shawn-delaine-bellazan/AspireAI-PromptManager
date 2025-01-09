using System.ComponentModel.DataAnnotations;

namespace ProjectName.DataService.Dtos
{
    public class CreatePromptDto
    {
        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? PromptDesignId { get; set; }
    }
}
