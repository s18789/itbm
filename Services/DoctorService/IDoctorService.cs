using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task DeleteDoctor(string doctorPersonalNumber);
        Task<bool> IsPossibleToDeleteOrUpdateDoctor(string doctorPersonalNumber);
        Task UpdateDoctor(string doctorPersonalNumber, string firstName, string lastName);
    }
}
