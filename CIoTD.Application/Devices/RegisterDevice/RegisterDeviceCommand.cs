using CIoTD.Application.Abstractions.Messaging;
using CIoTD.Domain.Devices.Dtos;

namespace CIoTD.Application.Devices.CreateDevice;

public record RegisterDeviceCommand(
        string Identifier,
        string Description,
        string Manufacturer,
        string Url,
        List<CommandDescriptionDto> Commands
    ) : ICommand<string>;