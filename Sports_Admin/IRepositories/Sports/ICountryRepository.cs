using Sports_Admin_Core.Entities;
using Sports_Admin_Core.IRepositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Admin_Core.IRepositories.Sports
{
    public interface ICountryRepository : IRepository<Guid, Country>
    {
    }
}
