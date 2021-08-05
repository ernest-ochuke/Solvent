using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BankRepository : IBankRepository
    {
        private readonly SolventContext e_context;
        public BankRepository(SolventContext context)
        {
            e_context = context;

        }
        public async Task<Bank> GetBankByIdAsync(int id)
        {
           return await e_context.Banks.Include(x=>x.CardProducts).Where(x=>x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Bank>> GetBanksAsync()
        {
           return await e_context.Banks.Include(x=>x.CardProducts).ToListAsync();
        }
    }
}