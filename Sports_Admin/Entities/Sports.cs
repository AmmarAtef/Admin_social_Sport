﻿using Sports_Admin_Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Admin_Core.Entities
{
    public class Sport : FullAuditedBaseEntity<Guid>
    {
        public List<League> Leagues { get; set; }
    }
}
