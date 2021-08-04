using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBankRepository
    {
         
        Task <Bank> GetBankByIdAsync(int id);
         
         Task<IReadOnlyList<Bank>> GetBanksAsync();
    }
}