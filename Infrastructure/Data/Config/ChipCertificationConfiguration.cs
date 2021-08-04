using Core.Entities;
using Core.Entities.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Config
{
    public class ChipCertificationConfiguration : IEntityTypeConfiguration<ChipCertification>
    {
        public void Configure(EntityTypeBuilder<ChipCertification> builder)
        {
            var certTypeConverter = new EnumToStringConverter<CertificationType>();
             var certStatusConverter = new EnumToStringConverter<CertificationStatus>();
            builder
                .Property(p => p.CertificationStatus)
                .HasConversion(certStatusConverter);
            builder
                .Property(p => p.CertificationType)
                .HasConversion(certTypeConverter);
            
        }
    }
}