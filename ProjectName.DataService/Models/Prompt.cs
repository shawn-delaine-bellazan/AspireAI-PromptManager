﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int? PromptDesignId { get; set; }
        [ForeignKey("PromptDesignId")]
        public PromptDesign PromptDesign { get; set; }

    }
}
