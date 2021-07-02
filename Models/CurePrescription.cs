using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Models
{
    public class CurePrescription
    {
        public Cure Cure { get; set; }
        public int CureId { get; set; }
        public Prescription Prescription { get; set; }
        public int PrescriptionId { get; set; }
    }
}
