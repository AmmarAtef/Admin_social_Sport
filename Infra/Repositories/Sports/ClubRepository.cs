using Infra.Data_Identity;
using Microsoft.EntityFrameworkCore.Query;
using Sports_Admin_Core.Entities;
using Sports_Admin_Core.Entities.BaseEntities;
using Sports_Admin_Core.IRepositories.Sports;


namespace Infra.Repositories.Sports
{
    public class ClubRepository : BaseRepository<Guid, Club>, IClubRepository
    {
        private readonly AdminSportsContext _context;

        public ClubRepository(AdminSportsContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
