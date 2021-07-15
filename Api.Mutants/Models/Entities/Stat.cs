using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Models
{
    public class Stat
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsMutant { get; set; }

        public class StatMap : IEntityTypeConfiguration<Stat>
        {
            public void Configure(EntityTypeBuilder<Stat> builder)
            {
                builder.ToTable("Stats");
                builder.HasKey(i => i.Id);
                builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.RequestDate).HasColumnName("RequestDate").HasColumnType("datetime");
                builder.Property(s => s.IsMutant).HasColumnName("IsMutant").IsRequired();
            }
        }

    }
}
