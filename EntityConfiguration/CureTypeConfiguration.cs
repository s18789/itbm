using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.EntityConfiguration
{
    public class CureTypeConfiguration : IEntityTypeConfiguration<Cure>
    {
        public void Configure(EntityTypeBuilder<Cure> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.CureName).HasMaxLength(100).IsRequired();
        }
    }
}
