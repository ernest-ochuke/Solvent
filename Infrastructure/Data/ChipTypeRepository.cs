using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ChipTypeRepository : IChipTypeRepository
    {
        private readonly SolventContext e_context;
        public ChipTypeRepository(SolventContext context)
        {
            e_context = context;

        }

        public async Task<IReadOnlyList<ChipType>> ChipTypesAsync() => await e_context.ChipTypes.ToListAsync();

        public async Task<ChipType> GetChipTypeByIdAsync(int id) => await e_context.ChipTypes.FindAsync(id);
    }
}