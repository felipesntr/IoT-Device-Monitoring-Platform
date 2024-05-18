namespace CIoTD.Domain.Devices;

public class CommandDescription
{
    public CommandDescription() { }

    public CommandDescription(string operation, string description, Command command, string result, string format)
    {
        Operation = operation;
        Description = description;
        Command = command;
        Result = result;
        Format = format;
    }

    /// <summary>
    /// Nome da operação executada pelo dispositivo
    /// </summary>
    public string Operation { get; set; }
    /// <summary>
    /// Descrição e detalhes adicionais sobre a operação e/ou o comando
    /// </summary>
    public string Description { get; set; }

    public Command Command { get; set; }

    /// <summary>
    /// Descrição do resultado esperado da execução do comando
    /// </summary>
    public string Result { get; set; }
    /// <summary>
    /// Definição, usando o padrão OpenAPI para especificação de schemas de dados, do formato dos dados retornados pelo comando.
    /// </summary>
    public string Format { get; set; }
}

