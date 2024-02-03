using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sports_Admin_Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sports_Admin_Core.Entities.Identity;

namespace Infra.EntityConfigurations
{
    public class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }
}
