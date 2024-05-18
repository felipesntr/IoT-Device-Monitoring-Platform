using CIoTD.Domain.Devices;
using CIoTD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CIoTD.Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly ApplicationDbContext _context;

    public DeviceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Device> RegisterDeviceAsync(Device device)
    {
        _context.Devices.Add(device);
        await _context.SaveChangesAsync();
        return device;
    }

    public async Task<Device> GetDeviceByIdentifierAsync(string identifier)
    {
        return await _context.Devices
            .Include(d => d.Commands)
            .FirstOrDefaultAsync(d => d.Identifier == identifier);
    }

    public async Task<List<Device>> GetAllDevicesAsync()
    {
        return await _context.Devices
            .Include(d => d.Commands)
            .ToListAsync();
    }

    public async Task UpdateDeviceAsync(Device device)
    {
        _context.Devices.Update(device);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDeviceAsync(Device device)
    {
        _context.Devices.Remove(device);
        await _context.SaveChangesAsync();
    }
}
