using Sports_Admin_Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Admin_Core.Entities
{
    public class Club : FullAuditedBaseEntity<Guid>
    {
        public League League { get; set; }
        public ICollection<FavoriteClubs> FavoriteClubs { get; set; }
    }
}
