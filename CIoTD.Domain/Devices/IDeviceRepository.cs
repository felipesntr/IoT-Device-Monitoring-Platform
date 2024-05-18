namespace CIoTD.Domain.Devices;

public interface IDeviceRepository
{
    Task<Device> RegisterDeviceAsync(Device device);
    Task<List<Device>> GetAllDevicesAsync();
    Task<Device> GetDeviceByIdentifierAsync(string identifier);
    Task UpdateDeviceAsync(Device device);
    Task DeleteDeviceAsync(Device device);
}
