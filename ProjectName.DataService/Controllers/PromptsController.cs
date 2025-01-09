using Microsoft.AspNetCore.Mvc;
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

        public PromptsController(AIPromptService aiPromptService)
        {
            _aiPromptService = aiPromptService;
        }

        /// <summary>
        /// Retrieves all prompts.
        /// </summary>
        /// <response code="200">Returns all prompts.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prompt>>> GetPrompts()
        {
            var prompts = await _aiPromptService.GetAllPromptsAsync();
            return Ok(prompts);
        }

        /// <summary>
        /// Retrieves a specific prompt by its ID.
        /// </summary>
        /// <param name="id">The ID of the prompt to retrieve.</param>
        /// <response code="200">Returns the requested prompt.</response>
        /// <response code="404">If the prompt is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Prompt>> GetPrompt(int id)
        {
            var prompt = await _aiPromptService.GetPromptByIdAsync(id);
            if (prompt == null)
            {
                return NotFound();
            }
            return Ok(prompt);
        }

        [HttpPost]
        public async Task<ActionResult<Prompt>> CreatePrompt(Prompt prompt)
        {
            await _aiPromptService.AddPromptAsync(prompt);
            return CreatedAtAction(nameof(GetPrompt), new { id = prompt.Id }, prompt);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrompt(int id, Prompt prompt)
        {
            if (id != prompt.Id)
            {
                return BadRequest();
            }

            await _aiPromptService.UpdatePromptAsync(prompt);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrompt(int id)
        {
            await _aiPromptService.DeletePromptAsync(id);
            return NoContent();
        }

        // Additional methods like GetPromptsForDesignAsync could be added
    }
}
