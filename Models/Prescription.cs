using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public ICollection<CurePrescription> CurePrescriptions { get; set; }
    }
}
