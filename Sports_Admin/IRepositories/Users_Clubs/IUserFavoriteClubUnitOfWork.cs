
using Sports_Admin_Core.IRepositories.Sports;

namespace Sports_Admin_Core.IRepositories.Users_Clubs
{
    public interface IUserFavoriteClubUnitOfWork
    {
        IClubRepository ClubRepository { get; }
        ICountryRepository countryRepository { get; }
        ILeagueRepository leagueRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
