using System.ComponentModel.DataAnnotations;

namespace ProjectName.DataService.Dtos
{
    public class CreatePromptDesignDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
