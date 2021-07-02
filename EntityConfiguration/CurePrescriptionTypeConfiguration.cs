using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.EntityConfiguration
{
    public class CurePrescriptionTypeConfiguration : IEntityTypeConfiguration<CurePrescription>
    {
        public void Configure(EntityTypeBuilder<CurePrescription> builder)
        {
            builder.ToTable("Cure_Prescription");
            builder.HasKey(cp => new {cp.CureId, cp.PrescriptionId });

            builder.Property(cp => cp.CureId).IsRequired();
            builder.Property(cp => cp.PrescriptionId).IsRequired();

            builder.HasOne(cp => cp.Cure)
                        .WithMany(m => m.CurePrescriptions)
                        .HasForeignKey(k => k.CureId);

            builder.HasOne(cp => cp.Prescription)
                        .WithMany(m => m.CurePrescriptions)
                        .HasForeignKey(k => k.PrescriptionId);
        }
    }
}
