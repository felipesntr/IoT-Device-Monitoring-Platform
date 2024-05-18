using CIoTD.Domain.Devices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIoTD.Infrastructure.Data.Configurations;

public class CommandDescriptionConfiguration : IEntityTypeConfiguration<CommandDescription>
{
    public void Configure(EntityTypeBuilder<CommandDescription> builder)
    {
        builder.HasKey(cd => cd.Operation);

        builder.Property(cd => cd.Operation)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(cd => cd.Description)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(cd => cd.Result)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(cd => cd.Format)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasOne(cd => cd.Command)
               .WithMany()
               .HasForeignKey("CommandBytes")
               .IsRequired();
    }
}
