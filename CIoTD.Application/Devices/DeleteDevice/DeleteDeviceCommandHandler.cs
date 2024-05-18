using CIoTD.Application.Abstractions.Messaging;
using CIoTD.Application.Devices.UpdateDevice;
using CIoTD.Domain.Abstractions;
using CIoTD.Domain.Devices;

namespace CIoTD.Application.Devices.DeleteDevice;

internal sealed class DeleteDeviceCommandHandler : ICommandHandler<DeleteDeviceCommand>
{
    private readonly IDeviceRepository _deviceRepository;

    public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await _deviceRepository.GetDeviceByIdentifierAsync(request.Identifier);
        if (device == null) 
            return Result.Failure(new("DeleteDevice", "Não foi possível encontrar o dispositivo a ser excluído."));
       
        await _deviceRepository.DeleteDeviceAsync(device);
        return Result.Success();
    }
}
