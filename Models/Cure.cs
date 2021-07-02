using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Models
{
    public class Cure
    {
        public int Id { get; set; }
        public string CureName { get; set; }
        public ICollection<CurePrescription> CurePrescriptions { get; set; }
    }
}
