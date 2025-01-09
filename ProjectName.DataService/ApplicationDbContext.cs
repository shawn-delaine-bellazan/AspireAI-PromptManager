using Microsoft.EntityFrameworkCore;
using ProjectName.DataService.Models;

namespace ProjectName.DataService
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<PromptDesign> PromptDesigns { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prompt>()
                .HasOne(p => p.PromptDesign)
                .WithMany(pd => pd.Prompts)
                .HasForeignKey(p => p.PromptDesignId);
        }

    }
}
