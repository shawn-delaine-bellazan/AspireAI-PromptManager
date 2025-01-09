using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectName.DataService.Dtos;
using ProjectName.DataService.Models;
using ProjectName.DataService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectName.DataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptsController : ControllerBase
    {
        private readonly AIPromptService _aiPromptService;
        private readonly IMapper _mapper;

        public PromptsController(AIPromptService aiPromptService, IMapper mapper)
        {
            _aiPromptService = aiPromptService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromptDto>>> GetPrompts()
        {
            var prompts = await _aiPromptService.GetAllPromptsAsync();
            return Ok(_mapper.Map<IEnumerable<PromptDto>>(prompts));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromptDto>> GetPrompt(int id)
        {
            var prompt = await _aiPromptService.GetPromptByIdAsync(id);
            if (prompt == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PromptDto>(prompt));
        }

        /// <summary>
        /// Creates a new prompt.
        /// </summary>
        /// <param name="createPromptDto">The data for creating a new prompt.</param>
        /// <returns>The created prompt with its ID.</returns>
        [HttpPost]
        public async Task<ActionResult<PromptDto>> CreatePrompt([FromBody] CreatePromptDto createPromptDto)
        {
            // Map the DTO to the entity
            var prompt = _mapper.Map<Prompt>(createPromptDto);

            // Use the service to add the prompt
            await _aiPromptService.AddPromptAsync(prompt);

            // Map the created entity back to DTO for response
            var result = _mapper.Map<PromptDto>(prompt);

            // Return the result with the correct status code
            return CreatedAtAction(nameof(GetPrompt), new { id = result.Id }, result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrompt(int id, PromptDto promptDto)
        {
            if (id != promptDto.Id)
            {
                return BadRequest();
            }

            var prompt = _mapper.Map<Prompt>(promptDto);
            await _aiPromptService.UpdatePromptAsync(prompt);
            return NoContent();
        }

    }
}
