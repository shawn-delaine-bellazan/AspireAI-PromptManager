using Microsoft.AspNetCore.Mvc;
using ProjectName.DataService.Models;
using ProjectName.DataService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectName.DataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptDesignsController : ControllerBase
    {
        private readonly AIPromptService _aiPromptService;

        public PromptDesignsController(AIPromptService aiPromptService)
        {
            _aiPromptService = aiPromptService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromptDesign>>> GetPromptDesigns()
        {
            var designs = await _aiPromptService.GetAllPromptDesignsAsync();
            return Ok(designs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromptDesign>> GetPromptDesign(int id)
        {
            var design = await _aiPromptService.GetPromptDesignByIdAsync(id);
            if (design == null)
            {
                return NotFound();
            }
            return Ok(design);
        }

        [HttpPost]
        public async Task<ActionResult<PromptDesign>> CreatePromptDesign(PromptDesign design)
        {
            await _aiPromptService.AddPromptDesignAsync(design);
            return CreatedAtAction(nameof(GetPromptDesign), new { id = design.Id }, design);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePromptDesign(int id, PromptDesign design)
        {
            if (id != design.Id)
            {
                return BadRequest();
            }

            await _aiPromptService.UpdatePromptDesignAsync(design);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromptDesign(int id)
        {
            await _aiPromptService.DeletePromptDesignAsync(id);
            return NoContent();
        }
    }
}
