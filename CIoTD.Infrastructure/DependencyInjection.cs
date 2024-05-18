using CIoTD.Domain.Devices;
using CIoTD.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CIoTD.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDeviceRepository, DeviceRepository>();

        return services;
    }
}