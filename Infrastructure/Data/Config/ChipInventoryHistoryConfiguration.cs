using Core.Entities;
using Core.Entities.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Config
{
    public class ChipInventoryHistoryConfiguration : IEntityTypeConfiguration<ChipInventoryHistory>
    {
        public void Configure(EntityTypeBuilder<ChipInventoryHistory> builder)
        {
              var requestConverter = new EnumToStringConverter<RequestType>();
             builder
                .Property(p => p.Action)
                .HasConversion(requestConverter);
             builder
             .Property(p=>p.Quantity).HasMaxLength(255);
        }
    }
}