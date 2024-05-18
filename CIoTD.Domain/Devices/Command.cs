namespace CIoTD.Domain.Devices;

public sealed class Command
{
    public Command() { }

    public Command(string commandBytes, List<Parameter> parameters)
    {
        CommandBytes = commandBytes;
        Parameters = parameters;
    }

    /// <summary>
    /// Sequencia de bytes enviados para execução do comando
    /// </summary>
    public string CommandBytes { get; set; }
    /// <summary>
    /// Lista de parâmetros aceitas pelo comando
    /// </summary>
    public List<Parameter> Parameters { get; set; }
}
