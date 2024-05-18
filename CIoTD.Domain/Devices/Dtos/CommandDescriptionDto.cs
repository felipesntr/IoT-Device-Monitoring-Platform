namespace CIoTD.Domain.Devices.Dtos;

public sealed record CommandDescriptionDto(
    string Operation,
    string Description,
    CommandDto Command,
    string Result,
    string Format);
