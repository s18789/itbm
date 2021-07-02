using Microsoft.EntityFrameworkCore;
using MVCprojectOne.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Models
{
    public class MainDbContext : DbContext
    {

        public MainDbContext(){}

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {}

        public DbSet<Cure> Cures { get; set; }
        public DbSet<CurePrescription> CurePrescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localDb)\\MSSQLLocalDb;Initial Catalog=Artisto;Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CureTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CurePrescriptionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PatientTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionTypeConfiguration());
        }
    }
}
