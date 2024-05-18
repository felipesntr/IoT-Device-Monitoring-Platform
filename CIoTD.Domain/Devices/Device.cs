using CIoTD.Domain.Devices.Dtos;

namespace CIoTD.Domain.Devices;

public sealed class Device
{
    public Device() { }

    public Device(string identifier, string description, string manufacturer, string url, List<CommandDescription> commands)
    {
        Identifier = identifier;
        Description = description;
        Manufacturer = manufacturer;
        Url = url;
        Commands = commands;
    }

    /// <summary>
    /// Identificador do dispositivo
    /// </summary>
    public string Identifier { get; set; }
    /// <summary>
    /// Descrição do dispositivo, incluindo detalhes do seu uso e das informações geradas
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Nome do fabricante do dispositivo
    /// </summary>
    public string Manufacturer { get; set; }
    /// <summary>
    /// URL de acesso ao dispositivo
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// Lista de comandos disponibilizada pelo dispositivo
    /// </summary>
    public List<CommandDescription> Commands { get; set; }

    public static DeviceDto ToDto(Device device)
    {
        return new DeviceDto(
            device.Identifier,
            device.Description,
            device.Manufacturer,
            device.Url,
            device.Commands.Select(x => new CommandDescriptionDto(
                x.Operation,
                x.Description,
                new CommandDto(
                    x.Command.CommandBytes,
                    x.Command.Parameters.Select(y =>
                        new ParameterDto(y.Name, y.Description)).ToList()),
                x.Result,
                x.Format
            )).ToList()
        );
    }
}
