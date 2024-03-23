using Infra.Data_Identity;
using Sports_Admin_Core.Entities;
using Sports_Admin_Core.IRepositories.GenericRepository;
using Sports_Admin_Core.IRepositories.Users_Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Sports
{
    public class FavoriteClubsRepository: BaseRepository<Guid, FavoriteClubs>, IFavoritClubRepository
    {
        private readonly AdminSportsContext _context;

        public FavoriteClubsRepository(AdminSportsContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
