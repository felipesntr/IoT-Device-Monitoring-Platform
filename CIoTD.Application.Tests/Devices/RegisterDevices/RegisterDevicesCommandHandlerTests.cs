using CIoTD.Application.Devices.CreateDevice;
using CIoTD.Domain.Devices;
using CIoTD.Domain.Devices.Dtos;
using FluentAssertions;
using Moq;

public class RegisterDeviceCommandHandlerAdditionalTests
{
    private readonly Mock<IDeviceRepository> _deviceRepositoryMock;
    private readonly RegisterDeviceCommandHandler _handler;

    public RegisterDeviceCommandHandlerAdditionalTests()
    {
        _deviceRepositoryMock = new Mock<IDeviceRepository>();
        _handler = new RegisterDeviceCommandHandler(_deviceRepositoryMock.Object);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="identifier"></param>
    /// <returns></returns>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Handle_ShouldReturnFailure_WhenIdentifierIsNullOrEmpty(string identifier)
    {
        // Arrange
        var command = CreateCommand(identifier, "Description", "Manufacturer", "http://example.com");

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Handle_ShouldReturnFailure_WhenDescriptionIsNullOrEmpty(string description)
    {
        // Arrange
        var command = CreateCommand("Device123", description, "Manufacturer", "http://example.com");

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="manufacturer"></param>
    /// <returns></returns>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Handle_ShouldReturnFailure_WhenManufacturerIsNullOrEmpty(string manufacturer)
    {
        // Arrange
        var command = CreateCommand("Device123", "Description", manufacturer, "http://example.com");

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("invalid-url")]
    public async Task Handle_ShouldReturnFailure_WhenUrlIsInvalid(string url)
    {
        // Arrange
        var command = CreateCommand("Device123", "Description", "Manufacturer", url);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenCommandsAreNull()
    {
        // Arrange
        var command = new RegisterDeviceCommand("Device123", "Description", "Manufacturer", "http://example.com", null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenCommandsContainNullCommand()
    {
        // Arrange
        var command = CreateCommand("Device123", "Description", "Manufacturer", "http://example.com", new List<CommandDescriptionDto>
        {
            new CommandDescriptionDto(
                "Operation",
                "Description",
                null,
                "Result",
                "Format"
            )
        });

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    /// <summary>
    /// Se algum command tiver algum "parameter" null deve retornar failure.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenCommandsContainNullParameterInCommand()
    {
        // Arrange
        var command = CreateCommand("Device123", "Description", "Manufacturer", "http://example.com", new List<CommandDescriptionDto>
        {
            new CommandDescriptionDto(
                "Operation",
                "Description",
                new CommandDto("Command", new List<ParameterDto>
                {
                    null
                }),
                "Result",
                "Format"
            )
        });



        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="identifier"></param>
    /// <param name="description"></param>
    /// <param name="manufacturer"></param>
    /// <param name="url"></param>
    /// <param name="commands"></param>
    /// <returns></returns>
    private RegisterDeviceCommand CreateCommand(string identifier, string description, string manufacturer, string url, List<CommandDescriptionDto> commands = null)
    {
        return new RegisterDeviceCommand(
            identifier,
            description,
            manufacturer,
            url,
            commands ?? new List<CommandDescriptionDto>
            {
                new CommandDescriptionDto(
                    "Operation",
                    "Description",
                    new CommandDto("Command", new List<ParameterDto>
                    {
                        new ParameterDto("Param1", "Description1")
                    }),
                    "Result",
                    "Format"
                )
            }
        );
    }
}
