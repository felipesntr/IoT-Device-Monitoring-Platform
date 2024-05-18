using CIoTD.Application.Abstractions.Messaging;

namespace CIoTD.Application.Devices.GetDeviceIdentifiersQuery;

public sealed record GetDeviceIdentifiersQuery() : IQuery<List<string>>;