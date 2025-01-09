using Microsoft.EntityFrameworkCore;
using ProjectName.DataService.Models;
using ProjectName.DataService.Repositories.Interfaces;

namespace ProjectName.DataService.Repositories
{
    public class PromptDesignRepository : Repository<PromptDesign>, IPromptDesignRepository
    {
        public PromptDesignRepository(ApplicationDbContext context) : base(context) { }


    }
}
