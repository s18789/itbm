using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Models
{
    public class Patient
    {
        public string PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
