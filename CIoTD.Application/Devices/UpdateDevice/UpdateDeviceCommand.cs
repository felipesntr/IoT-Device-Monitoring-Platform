using CIoTD.Application.Abstractions.Messaging;
using CIoTD.Domain.Devices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIoTD.Application.Devices.UpdateDevice;

public sealed record UpdateDeviceCommand(
    string Identifier,
    string Description,
    string Manufacturer,
    string Url,
    List<CommandDescriptionDto> Commands) : ICommand<DeviceDto>;