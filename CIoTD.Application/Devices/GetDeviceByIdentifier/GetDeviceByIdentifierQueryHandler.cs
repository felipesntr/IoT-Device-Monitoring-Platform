using CIoTD.Application.Abstractions.Messaging;
using CIoTD.Application.Devices.GetDeviceByIdentifier;
using CIoTD.Domain.Abstractions;
using CIoTD.Domain.Devices;
using CIoTD.Domain.Devices.Dtos;

namespace CIoTD.Application.Devices.GetDeviceIdentifiersQuery;

internal sealed class GetDeviceByIdentifierQueryHandler : IQueryHandler<GetDeviceByIdentifierQuery, DeviceDto>
{
    public readonly IDeviceRepository _deviceRepository;

    public GetDeviceByIdentifierQueryHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<DeviceDto>> Handle(GetDeviceByIdentifierQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var device = await _deviceRepository.GetDeviceByIdentifierAsync(request.Identifier);
            return Result.Success(Device.ToDto(device));
        } catch (Exception)
        {
            return Result.Failure<DeviceDto>(new Error("DeviceByIdentifier.Failed", "Falha ao tentar obter o dispositivo pelo Identifier."));
        }
    }
}
