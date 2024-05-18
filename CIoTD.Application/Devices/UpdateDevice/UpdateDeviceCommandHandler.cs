using CIoTD.Application.Abstractions.Messaging;
using CIoTD.Domain.Abstractions;
using CIoTD.Domain.Devices;
using CIoTD.Domain.Devices.Dtos;

namespace CIoTD.Application.Devices.UpdateDevice;

internal sealed class UpdateDeviceCommandHandler : ICommandHandler<UpdateDeviceCommand, DeviceDto>
{
    public readonly IDeviceRepository _deviceRepository;

    public UpdateDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<DeviceDto>> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var device = await _deviceRepository.GetDeviceByIdentifierAsync(request.Identifier);
            if (device == null)
                return Result.Failure<DeviceDto>(new("UpdateDevice", "Não foi possível encontrar o dispositivo para atualizar."));

            device.Description = request.Description;
            device.Manufacturer = request.Manufacturer;
            device.Url = request.Url;
            device.Commands = request.Commands.Select(x => new CommandDescription(
                x.Operation,
                x.Description,
                new Command(x.Command.Command, x.Command.Parameters.Select(y =>
                    new Parameter(y.Name, y.Description)).ToList()),
                x.Result,
                x.Format
            )).ToList();

            await _deviceRepository.UpdateDeviceAsync(device);

            return Result.Success(Device.ToDto(device));
        } catch (Exception)
        {
            return Result.Failure<DeviceDto>(new("UpdateDevice", "Não foi possível atualizar o dispositivo."));
        }
    }
}