using ProjectName.DataService.Models;
using ProjectName.DataService.Repositories.Interfaces;

namespace ProjectName.DataService.Services
{
    public class AIPromptService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AIPromptService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Prompt>> GetAllPromptsAsync() => await _unitOfWork.Prompts.GetAllAsync();
        public async Task<Prompt> GetPromptByIdAsync(int id) => await _unitOfWork.Prompts.GetByIdAsync(id);
        public async Task AddPromptAsync(Prompt prompt) => await _unitOfWork.Prompts.AddAsync(prompt);
        public async Task UpdatePromptAsync(Prompt prompt) => await _unitOfWork.Prompts.UpdateAsync(prompt);
        public async Task DeletePromptAsync(int id) => await _unitOfWork.Prompts.DeleteAsync(id);

        public async Task<IEnumerable<PromptDesign>> GetAllPromptDesignsAsync() => await _unitOfWork.PromptDesigns.GetAllAsync();
        public async Task<PromptDesign> GetPromptDesignByIdAsync(int id) => await _unitOfWork.PromptDesigns.GetByIdAsync(id);
        public async Task AddPromptDesignAsync(PromptDesign design) => await _unitOfWork.PromptDesigns.AddAsync(design);
        public async Task UpdatePromptDesignAsync(PromptDesign design) => await _unitOfWork.PromptDesigns.UpdateAsync(design);
        public async Task DeletePromptDesignAsync(int id) => await _unitOfWork.PromptDesigns.DeleteAsync(id);


    }
}
