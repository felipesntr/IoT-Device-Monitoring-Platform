namespace CIoTD.Domain.Devices.Dtos;

public sealed record DeviceDto(string Identifier, string Description, string Manufacturer, string Url, List<CommandDescriptionDto> Commands);