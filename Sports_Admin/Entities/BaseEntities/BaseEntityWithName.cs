using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Admin_Core.Entities.BaseEntities
{
    public abstract class BaseEntityWithName<TKeyType> :BaseEntity<TKeyType>
    {
        public int Name { get; set; }
    }
}
