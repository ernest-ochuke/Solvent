using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(250);
            builder.HasIndex(p=>p.UniqueIdentityNumber).IsUnique();
            builder.HasIndex(i=>i.Name).IsUnique();
            
        }
    }
}