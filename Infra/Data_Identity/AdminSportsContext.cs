
using Microsoft.EntityFrameworkCore;
using Sports_Admin_Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sports_Admin_Core.Entities;
using Infra.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infra.Data_Identity
{
    public class AdminSportsContext : IdentityDbContext<AppUser, AppRole, Guid>
    {

        public AdminSportsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sport> Sports { get; set; }
        public DbSet<AppUser> AdminUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //sports table
            modelBuilder.ApplyConfiguration(new SportsConfigurations());
            SportsConfigurations.Seed(modelBuilder);


            //appuser and approle
            modelBuilder.ApplyConfiguration(new AppUserConfigurations());
            modelBuilder.ApplyConfiguration(new AppRoleConfigurations());
            

            base.OnModelCreating(modelBuilder);
        }

    }
}
