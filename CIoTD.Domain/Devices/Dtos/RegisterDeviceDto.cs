namespace CIoTD.Domain.Devices.Dtos;

public sealed record RegisterDeviceDto(
        string Identifier,
        string Description,
        string Manufacturer,
        string Url,
        List<CommandDescriptionDto> Commands
    );