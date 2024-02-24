
using Microsoft.EntityFrameworkCore;
using Sports_Admin_Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sports_Admin_Core.Entities;
using Infra.EntityConfigurations;

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
        public DbSet<League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sports table
            modelBuilder.ApplyConfiguration(new SportsConfigurations());
            SportsConfigurations.Seed(modelBuilder);


            // Appuser and approle
            modelBuilder.ApplyConfiguration(new AppUserConfigurations());
            modelBuilder.ApplyConfiguration(new AppRoleConfigurations());

            // League table
            modelBuilder.ApplyConfiguration(new LeagueConfigurations());

            // Country table
            modelBuilder.ApplyConfiguration(new CountryConfigurations());

            // Club table
            modelBuilder.ApplyConfiguration(new ClubConfigurations());

            // Favorite Clubs
            modelBuilder.ApplyConfiguration(new FavoriteClubsConfigurations());

            base.OnModelCreating(modelBuilder);
        }

    }
}
