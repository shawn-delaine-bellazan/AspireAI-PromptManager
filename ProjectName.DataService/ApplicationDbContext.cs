using Microsoft.EntityFrameworkCore;
using ProjectName.DataService.Models;

namespace ProjectName.DataService
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<PromptDesign> PromptDesigns { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Prompt>()
                .HasOne(p => p.PromptDesign)
                .WithMany(pd => pd.Prompts)
                .HasForeignKey(p => p.PromptDesignId);

            modelBuilder.Entity<Prompt>()
                .HasOne(p => p.User)
                .WithMany(u => u.Prompts)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<PromptDesign>()
                .HasOne(pd => pd.User)
                .WithMany(u => u.PromptDesigns)
                .HasForeignKey(pd => pd.UserId);
        }

    }
}
