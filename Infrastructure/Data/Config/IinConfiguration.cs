using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class IinConfiguration : IEntityTypeConfiguration<Iin>
    {
        public void Configure(EntityTypeBuilder<Iin> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(250);
            builder.HasIndex(p=>p.Pan).IsUnique();
            builder.Property(i=>i.Pan).HasMaxLength(9);

        }
    }
}