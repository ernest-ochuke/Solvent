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
        public DbSet<ChipCertification> ChipCertifications { get; set; }
        public DbSet<CardProduct> CardProducts { get; set; }

        public DbSet<ChipInventory> ChipInventories { get; set; }
        public DbSet<ChipInventoryHistory> ChipInventoryHistories { get; set; }
        public DbSet<ChipType> ChipTypes { get; set; }
    }
}