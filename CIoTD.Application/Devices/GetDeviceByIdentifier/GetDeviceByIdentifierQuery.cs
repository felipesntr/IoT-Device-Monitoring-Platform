using CIoTD.Application.Abstractions.Messaging;
using CIoTD.Domain.Devices.Dtos;

namespace CIoTD.Application.Devices.GetDeviceByIdentifier;

public sealed record GetDeviceByIdentifierQuery(string Identifier) : IQuery<DeviceDto>;