using Infra.Data_Identity;
using Sports_Admin_Core.Entities;
using Sports_Admin_Core.IRepositories.Sports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Sports
{
    public class LeagueRepository: BaseRepository<Guid, League>, ILeagueRepository 
    {
        private readonly AdminSportsContext _context;

        public LeagueRepository(AdminSportsContext context):base(context)
        {
            _context = context;
        }

    }
}
