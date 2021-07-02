using Microsoft.EntityFrameworkCore;
using MVCprojectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Services.CureService
{
    public class CureService : ICureService
    {

        private MainDbContext _context = new MainDbContext();

        public async Task<IEnumerable<Cure>> GetCures()
        {
            return await _context.Cures.ToListAsync();
        }

        public async Task<bool> IsPossibleToDeleteOrUpdateCure(int cureId)
        {
            var curePrescriptionList = await _context.CurePrescriptions
                                            .Where(cp => cp.CureId == cureId).ToListAsync();

            return curePrescriptionList.Any();
        }

        public async Task DeleteCure(int cureId)
        {
            var cure = await _context.Cures
                                    .Where(c => c.Id == cureId).FirstAsync();

            _context.Cures.Remove(cure);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCure(int cureId, string name)
        {
            var Cure = await _context.Cures
                            .Where(c => c.Id == cureId).FirstAsync();

            Cure.CureName = name;

            await _context.SaveChangesAsync();
        }
    }
}
