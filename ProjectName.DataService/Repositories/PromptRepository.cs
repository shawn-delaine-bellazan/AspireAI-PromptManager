using Microsoft.EntityFrameworkCore;
using ProjectName.DataService.Models;
using ProjectName.DataService.Repositories.Interfaces;

namespace ProjectName.DataService.Repositories
{
    public class PromptRepository : Repository<Prompt>, IPromptRepository
    {
        public PromptRepository(ApplicationDbContext context) : base(context) { }

        // Example of a specific method for Prompt
        public async Task<IEnumerable<Prompt>> GetPromptsByDesignIdAsync(int designId)
        {
            return await _context.Prompts.Where(p => p.PromptDesignId == designId).ToListAsync();
        }
    }
}
