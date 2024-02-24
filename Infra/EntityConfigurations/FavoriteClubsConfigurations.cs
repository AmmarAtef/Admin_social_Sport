using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sports_Admin_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfigurations
{
    public class FavoriteClubsConfigurations : IEntityTypeConfiguration<FavoriteClubs>
    {
        public void Configure(EntityTypeBuilder<FavoriteClubs> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ClubId });

            builder.HasOne(x => x.User)
                .WithMany(c => c.FavoriteClubs)
                .HasForeignKey(c => c.UserId);

            builder.HasOne(x => x.Club)
                .WithMany(c => c.FavoriteClubs)
                .HasForeignKey(c => c.ClubId);
        }
    }
}
