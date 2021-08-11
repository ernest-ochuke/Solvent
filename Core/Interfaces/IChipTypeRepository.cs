using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IChipTypeRepository
    {
        Task<ChipType> GetChipTypeByIdAsync(int id);

        Task<IReadOnlyList<ChipType>> ChipTypesAsync();
    }
}