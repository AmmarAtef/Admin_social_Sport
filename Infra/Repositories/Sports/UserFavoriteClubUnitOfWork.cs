using AutoMapper;
using Infra.Data_Identity;
using Sports_Admin_Core.IRepositories.Sports;
using Sports_Admin_Core.IRepositories.Users_Clubs;

namespace Infra.Repositories.Sports
{
    public class UserFavoriteClubUnitOfWork : IUserFavoriteClubUnitOfWork
    {
        private readonly AdminSportsContext _context;
        
        public UserFavoriteClubUnitOfWork(AdminSportsContext context)
        {
            _context = context;
        }


        public IClubRepository ClubRepository => new ClubRepository(_context);

        public ICountryRepository countryRepository => new CountryRepository(_context);

        public ILeagueRepository leagueRepository => new LeagueRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
