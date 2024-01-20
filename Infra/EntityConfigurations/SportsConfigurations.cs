using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sports_Admin_Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfigurations
{
    public class SportsConfigurations : IEntityTypeConfiguration<Sports>
    {
        public void Configure(EntityTypeBuilder<Sports> builder)
        {
            builder.HasIndex(
                s=>s.Id
                ).IsUnique();


        }
    }
}
