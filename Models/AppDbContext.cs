using ChatBotModelAPI.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatBotModelAPI.Models
{
    // You can Change DbContext to your desired name
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSets

        public virtual DbSet<AppUser> appUsers { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        #endregion

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Roles Seed
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                // Add Admin Role
                entity.HasData(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

                // Add User Role
                entity.HasData(new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                });

                // Add SuperAdmin Role
                entity.HasData(new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                });
            });
            #endregion

            #region Relationships
            // Restrict delete behavior to avoid accidental deletion of related entities
            // Helps in avoiding orphaned records in the database
            // Helps in preventing cascading delete, to prevent cycles or multiple cascade paths
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            #endregion

            // Add your model configurations here
        }
    }
}
