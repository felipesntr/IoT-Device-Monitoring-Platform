using CIoTD.Domain.Devices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIoTD.Infrastructure.Data.Configurations;

public class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.HasKey(d => d.Identifier);

        builder.Property(d => d.Description)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(d => d.Manufacturer)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.Url)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasMany(d => d.Commands)
               .WithOne()
               .HasForeignKey("DeviceId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
