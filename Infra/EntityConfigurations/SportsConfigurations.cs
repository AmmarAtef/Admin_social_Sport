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
    public class SportsConfigurations : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.HasKey(s => s.Id);
        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            List<Sport> entities = new List<Sport>{
                new Sport
                {
                    Id = Guid.NewGuid(),
                    Name = "Football",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                },
                new Sport
                {
                     Id = Guid.NewGuid(),
                    Name = "Basketball",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                }
            };
            modelBuilder.Entity<Sport>().HasData(entities);
        }

    }
}
