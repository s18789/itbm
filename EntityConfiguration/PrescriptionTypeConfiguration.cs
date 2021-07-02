using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.EntityConfiguration
{
    public class PrescriptionTypeConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Date).IsRequired();

            builder.HasOne(p => p.Doctor)
                        .WithMany(m => m.Prescriptions)
                        .HasForeignKey(k => k.DoctorId);

            builder.HasOne(p => p.Patient)
                        .WithMany(m => m.Prescriptions)
                        .HasForeignKey(k => k.PatientId);
        }
    }
}
