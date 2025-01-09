﻿using ProjectName.DataService.Models;

namespace ProjectName.DataService.Repositories.Interfaces
{
    // Interface for PromptDesignRepository
    public interface IPromptDesignRepository : IRepository<PromptDesign>
    {
        Task<IEnumerable<PromptDesign>> GetDesignsByUserIdAsync(int userId);
    }
}
