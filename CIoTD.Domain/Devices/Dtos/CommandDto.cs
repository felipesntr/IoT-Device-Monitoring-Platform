namespace CIoTD.Domain.Devices.Dtos;

public sealed record CommandDto(
    string Command,
    List<ParameterDto> Parameters
    );
