namespace CIoTD.Domain.Devices;

public sealed class Parameter
{
    public Parameter() { }
    public Parameter(string name, string description)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Nome do parâmetro
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Descrição do parâmetro, incluindo detalhes de sua utilização, valores possíveis e 
    /// funcionamento experado da operação de acordo com esses valores
    /// </summary>
    public string Description { get; set; }
}
