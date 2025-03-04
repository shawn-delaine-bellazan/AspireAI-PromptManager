﻿using System.ComponentModel.DataAnnotations;

namespace ProjectName.DataService.Models
{
    public class PromptDesign : BaseEntity
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<Prompt> Prompts { get; set; }
    }
}
