namespace ProjectName.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPromptRepository Prompts { get; }
        IPromptDesignRepository PromptDesigns { get; }
        // Add other repositories as needed

        Task<int> CommitAsync();
    }
}
