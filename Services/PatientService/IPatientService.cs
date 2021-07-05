using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Services.PatientService
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<bool> IsPossibleToUpdateOrDeletePatient(string personalNumber);
        Task DeletePatient(string personalNumber);
        Task UpdatePatient(string personalNumber, string firstName, string lastName);
    }
}
