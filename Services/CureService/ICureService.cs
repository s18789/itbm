using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Services.CureService
{
    public interface ICureService
    {
        Task<IEnumerable<Cure>> GetCures();
        Task DeleteCure(int cureId);
        Task<bool> IsPossibleToDeleteOrUpdateCure(int cureId);
        Task UpdateCure(int cureId, string name);
    }
}
