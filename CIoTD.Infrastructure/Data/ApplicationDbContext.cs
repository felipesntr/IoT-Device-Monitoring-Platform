using CIoTD.Domain.Devices;
using CIoTD.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CIoTD.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Command> Commands { get; set; }
    public DbSet<CommandDescription> CommandDescriptions { get; set; }
    public DbSet<Parameter> Parameters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DeviceConfiguration());
        modelBuilder.ApplyConfiguration(new CommandConfiguration());
        modelBuilder.ApplyConfiguration(new CommandDescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new ParameterConfiguration());
    }
}
