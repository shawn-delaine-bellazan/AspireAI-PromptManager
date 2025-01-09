using ProjectName.DataService.Repositories.Interfaces;

namespace ProjectName.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IPromptRepository _promptRepository;
        private IPromptDesignRepository _promptDesignRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IPromptRepository Prompts =>
            _promptRepository ??= new PromptRepository(_context);

        public IPromptDesignRepository PromptDesigns =>
            _promptDesignRepository ??= new PromptDesignRepository(_context);

        // Implement for other repositories if you have them

        public async Task<int> CommitAsync()
        {
            // Save changes to the database
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
