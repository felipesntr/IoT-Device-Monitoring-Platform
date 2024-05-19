using CIoTD.Application.Abstractions.Messaging;

namespace CIoTD.Application.Devices.GetDeviceIdentifiers;

public sealed record GetDeviceIdentifiersQuery() : IQuery<List<string>>;