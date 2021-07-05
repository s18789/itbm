using Microsoft.EntityFrameworkCore;
using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private MainDbContext _context = new MainDbContext();
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }
        public async Task<bool> IsPossibleToUpdateOrDeletePatient(string personalNumber)
        {
            var patientList = await _context.Prescriptions
                            .Where(p => p.PatientId == personalNumber).ToListAsync();

            return patientList.Any();
        }
        public async Task UpdatePatient(string personalNumber, string firstName, string lastName)
        {
            var patient = await _context.Patients
                                .Where(p => p.PersonalNumber == personalNumber).FirstAsync();

            patient.FirstName = firstName;
            patient.LastName = lastName;

            await _context.SaveChangesAsync();
        }
        public async Task DeletePatient(string personalNumber)
        {
            var patient = await _context.Patients
                                .Where(p => p.PersonalNumber == personalNumber).FirstAsync();

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

    }
}
