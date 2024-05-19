using CIoTD.Application.Abstractions.Messaging;
using CIoTD.Domain.Abstractions;
using CIoTD.Domain.Devices;

namespace CIoTD.Application.Devices.CreateDevice;

public sealed class RegisterDeviceCommandHandler : ICommandHandler<RegisterDeviceCommand, string>
{
    public readonly IDeviceRepository _deviceRepository;

    public RegisterDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<string>> Handle(RegisterDeviceCommand request, CancellationToken cancellationToken)
    {
        var exist = await _deviceRepository.GetDeviceByIdentifierAsync(request.Identifier);
        if (exist != null)
            return Result.Failure<string>(new Error("Device.Exist", "Já existe um dispositivo com esse identificador."));

        if (!request.IsValid())
            return Result.Failure<string>(new Error("RegisterDeviceCommand", "Command inválido."));

        var device = new Device
        {
            Identifier = request.Identifier,
            Description = request.Description,
            Manufacturer = request.Manufacturer,
            Url = request.Url,
            Commands = request.Commands.Select(x => new CommandDescription(
                    x.Operation,
                    x.Description,
                    new Command(
                        x.Command.Command,
                        x.Command.Parameters.Select(y =>
                            new Parameter(y.Name, y.Description)).ToList()),
                    x.Result,
                    x.Format
                )).ToList()
        };

        var response = await _deviceRepository.RegisterDeviceAsync(device);

        if (response is null)
            return Result.Failure<string>(new Error("Device.Null", "Não foi possível criar o dispositivo."));

        return Result.Success(device.Identifier);
    }
}