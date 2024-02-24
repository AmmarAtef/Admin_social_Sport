using Sports_Admin_Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Admin_Core.Entities
{
    public class League : FullAuditedBaseEntity<Guid>
    {
        public Sport Sport { get; set; }
        public Country Country { get; set; }
        public ICollection<Club> Clubs { get; set; }
    }
}
