using CIoTD.Application.Abstractions.Messaging;
using CIoTD.Domain.Abstractions;
using CIoTD.Domain.Devices.Dtos;
using MediatR;

namespace CIoTD.Application.Devices.CreateDevice;

public record RegisterDeviceCommand(
        string Identifier,
        string Description,
        string Manufacturer,
        string Url,
        List<CommandDescriptionDto> Commands
    ) : ICommand<string>
{
    public bool IsValid()
    {
        if (Commands is null)
            return false;
        if (Commands.Any(command => command.Command is null))
            return false;
        if (Commands.Any(x => x.SomeParameterAreNull()))
            return false;
        if (Commands.Any(command => command.Command.Parameters is null))
            return false;

        return true;
    }
}