using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.EntityConfiguration
{
    public class DoctorTypeConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.PersonalNumber);

            builder.Property(d => d.PersonalNumber).IsRequired();
            builder.Property(d => d.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(d => d.LastName).HasMaxLength(100).IsRequired();
        }
    }
}
