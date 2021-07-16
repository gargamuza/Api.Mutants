using Api.Mutants.Models.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Api.Mutants.Models
{
    public class Stat
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsMutant { get; set; }
        public string Dna { get; set; }

        public static explicit operator Stat(MutantRequest v)
        {
            if (v == null)
                return null;

            return new Stat { 
                Dna = $"[ { string.Join(",", v.dna) } ]",
                RequestDate = DateTime.Now,               
            };
        }

        public class StatMap : IEntityTypeConfiguration<Stat>
        {
            public void Configure(EntityTypeBuilder<Stat> builder)
            {
                builder.ToTable("Stats");
                builder.HasKey(i => i.Id);
                builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.RequestDate).HasColumnName("RequestDate").HasColumnType("datetime");
                builder.Property(s => s.IsMutant).HasColumnName("IsMutant").IsRequired();
                builder.Property(s => s.Dna).HasColumnName("Dna");
            }
        }
    }
}