using Microsoft.EntityFrameworkCore;
using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private MainDbContext _context = new MainDbContext();

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<bool> IsPossibleToDeleteOrUpdateDoctor(string doctorPersonalNumber)
        {
            var resultList = await _context.Prescriptions
                                .Where(d => d.DoctorId == doctorPersonalNumber).ToListAsync();

            return resultList.Any();
        }

        public async Task DeleteDoctor(string doctorPersonalNumber)
        {
            var doctor = await _context.Doctors
                                .Where(d => d.PersonalNumber == doctorPersonalNumber).FirstAsync();

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctor(string doctorPersonalNumber, string firstName, string lastName)
        {
            var doctor = await _context.Doctors
                                .Where(d => d.PersonalNumber == doctorPersonalNumber).FirstAsync();

            doctor.FirstName = firstName;
            doctor.LastName = lastName;

            await _context.SaveChangesAsync();
        }
    }
}
