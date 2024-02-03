using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Admin_Core.Entities.BaseEntities
{
    public class FullAuditedBaseEntity<TKeyType> : BaseEntityWithName<TKeyType>, IFullAuditedEntity
    {
        public bool IsDeleted { set; get; }
        public string? DeletedBy { set; get; }
        public DateTime? DeletedAt { set; get; }
    }
}
