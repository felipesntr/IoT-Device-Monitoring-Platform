using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIoTD.Domain.Devices.Dtos;

public sealed record UpdateDeviceDto(
    string Identifier,
    string Description,
    string Manufacturer,
    string Url,
    List<CommandDescriptionDto> Commands);