using CIoTD.Domain.Devices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIoTD.Infrastructure.Data.Configurations;

public class CommandConfiguration : IEntityTypeConfiguration<Command>
{
    public void Configure(EntityTypeBuilder<Command> builder)
    {
        builder.HasKey(c => c.CommandBytes);

        builder.Property(c => c.CommandBytes)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasMany(c => c.Parameters)
               .WithOne()
               .HasForeignKey("CommandBytes")
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
