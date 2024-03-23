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
    public class CountryRepository : BaseRepository<Guid,Country>, ICountryRepository
    {
        private readonly AdminSportsContext _context;

        public CountryRepository(AdminSportsContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
