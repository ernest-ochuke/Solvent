using System.Reflection;
using Core.Entities;
using Core.Entities.enums;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
        public DbSet<Iin> Iins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}