﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectName.DataService.Models;
using ProjectName.DataService.Models.Dtos;
using ProjectName.DataService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectName.DataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptDesignController : ControllerBase
    {
        private readonly AIPromptService _aiPromptService;
        private readonly IMapper _mapper;

        public PromptDesignController(AIPromptService aiPromptService, IMapper mapper)
        {
            _aiPromptService = aiPromptService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all prompt designs.
        /// </summary>
        /// <returns>A list of all prompt designs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromptDesignDto>>> GetPromptDesigns()
        {
            var designs = await _aiPromptService.GetAllPromptDesignsAsync();
            return Ok(_mapper.Map<IEnumerable<PromptDesignDto>>(designs));
        }

        /// <summary>
        /// Retrieves a specific prompt design by its ID.
        /// </summary>
        /// <param name="id">The ID of the prompt design to retrieve.</param>
        /// <returns>The requested prompt design or NotFound if not found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PromptDesignDto>> GetPromptDesign(int id)
        {
            var design = await _aiPromptService.GetPromptDesignByIdAsync(id);
            if (design == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PromptDesignDto>(design));
        }

        /// <summary>
        /// Creates a new prompt design.
        /// </summary>
        /// <param name="promptDesignDto">The prompt design data to create.</param>
        /// <returns>The created prompt design with its ID.</returns>
        [HttpPost]
        public async Task<ActionResult<PromptDesignDto>> CreatePromptDesign(AddPromptDesignDto promptDesignDto)
        {
            var promptDesign = _mapper.Map<PromptDesign>(promptDesignDto);
            await _aiPromptService.AddPromptDesignAsync(promptDesign);
            return CreatedAtAction(nameof(GetPromptDesign), new { id = promptDesign.Id }, _mapper.Map<PromptDesignDto>(promptDesign));
        }

        /// <summary>
        /// Updates an existing prompt design.
        /// </summary>
        /// <param name="id">The ID of the prompt design to update.</param>
        /// <param name="promptDesignDto">The updated prompt design data.</param>
        /// <returns>NoContent if successful, BadRequest if IDs do not match.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePromptDesign(int id, PromptDesignDto promptDesignDto)
        {
            if (id != promptDesignDto.Id)
            {
                return BadRequest();
            }

            var promptDesign = _mapper.Map<PromptDesign>(promptDesignDto);
            await _aiPromptService.UpdatePromptDesignAsync(promptDesign);
            return NoContent();
        }

        /// <summary>
        /// Deletes a prompt design by its ID.
        /// </summary>
        /// <param name="id">The ID of the prompt design to delete.</param>
        /// <returns>NoContent if successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromptDesign(int id)
        {
            await _aiPromptService.DeletePromptDesignAsync(id);
            return NoContent();
        }
    }
}
