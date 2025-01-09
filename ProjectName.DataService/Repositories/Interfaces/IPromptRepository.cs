using ProjectName.DataService.Models;

namespace ProjectName.DataService.Repositories.Interfaces
{
    public interface IPromptRepository : IRepository<Prompt>
    {
        Task<IEnumerable<Prompt>> GetPromptsByDesignIdAsync(int designId);
    }
}
