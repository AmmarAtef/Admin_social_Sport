using Sports_Admin_Core.IRepositories.Sports;

namespace Sports_Admin_Core.UnitOfWorks
{
    public interface IUserFavoriteClubUnitOfWork
    {
        IClubRepository ClubRepository { get; }
        ICountryRepository CountryRepository { get; }
        ILeagueRepository LeagueRepository { get; }

        Task<bool> Complete();
        bool HasChanges();
    }
}
