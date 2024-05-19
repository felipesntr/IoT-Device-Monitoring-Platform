using CIoTD.Application.Abstractions.Messaging;
using CIoTD.Domain.Abstractions;
using CIoTD.Domain.Devices;

namespace CIoTD.Application.Devices.GetDeviceIdentifiers;

internal sealed class GetDeviceIdentifiersQueryHandler : IQueryHandler<GetDeviceIdentifiersQuery, List<string>>
{
    public readonly IDeviceRepository _deviceRepository;

    public GetDeviceIdentifiersQueryHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<List<string>>> Handle(GetDeviceIdentifiersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var devices = await _deviceRepository.GetAllDevicesAsync();
            var deviceIdentifiers = devices.Select(device => device.Identifier).ToList();
            return Result.Success(deviceIdentifiers);
        } catch (Exception ex)
        {
            return Result.Failure<List<string>>(new Error("ListDevicesIdentifiers.Failed", "Falha ao tentar obter os identificadores dos dispositivos."));
        }
    }
}
