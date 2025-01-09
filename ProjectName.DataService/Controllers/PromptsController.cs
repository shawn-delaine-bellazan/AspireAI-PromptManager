using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectName.DataService.Models;
using ProjectName.DataService.Models.Dtos;
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

        [HttpPost]
        public async Task<ActionResult<PromptDto>> CreatePrompt(PromptDto promptDto)
        {
            var prompt = _mapper.Map<Prompt>(promptDto);
            await _aiPromptService.AddPromptAsync(prompt);
            return CreatedAtAction(nameof(GetPrompt), new { id = prompt.Id }, _mapper.Map<PromptDto>(prompt));
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
