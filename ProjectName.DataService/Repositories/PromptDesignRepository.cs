using Microsoft.EntityFrameworkCore;
using ProjectName.DataService.Models;
using ProjectName.DataService.Repositories.Interfaces;

namespace ProjectName.DataService.Repositories
{
    public class PromptDesignRepository : Repository<PromptDesign>, IPromptDesignRepository
    {
        public PromptDesignRepository(ApplicationDbContext context) : base(context) { }

        // Example of a specific method for PromptDesign
        public async Task<IEnumerable<PromptDesign>> GetDesignsByUserIdAsync(int userId)
        {
            return await _context.PromptDesigns.Where(pd => pd.UserId == userId).ToListAsync();
        }
    }
}
