using CIoTD.Application.Abstractions.Messaging;

namespace CIoTD.Application.Devices.UpdateDevice;

public sealed record DeleteDeviceCommand(string Identifier) : ICommand;