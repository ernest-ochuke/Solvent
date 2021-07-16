using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SolventContext: DbContext
    {
        public SolventContext(DbContextOptions<SolventContext> options): base(options)
        {
            
        }
        public DbSet<Bank> Banks { get; set; }
    }
}