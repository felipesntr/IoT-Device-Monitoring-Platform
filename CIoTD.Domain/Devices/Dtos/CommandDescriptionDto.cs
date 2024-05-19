namespace CIoTD.Domain.Devices.Dtos;

public sealed record CommandDescriptionDto(
    string Operation,
    string Description,
    CommandDto Command,
    string Result,
    string Format)
{
    public bool SomeParameterAreNull()
        => Command.Parameters.Any(x => x == null);
}
