using CIoTD.Application.Devices.CreateDevice;
using CIoTD.Application.Devices.GetDeviceByIdentifier;
using CIoTD.Application.Devices.GetDeviceIdentifiersQuery;
using CIoTD.Application.Devices.UpdateDevice;
using CIoTD.Domain.Devices;
using CIoTD.Domain.Devices.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CIoTD.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("device")]
    public class DeviceController : ControllerBase
    {
        private readonly ISender _sender;

        public DeviceController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Retorna uma lista contendo os identificadores dos dispositivos cadastrados na plataforma
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetDeviceIdentifiers()
        {
            var query = new GetDeviceIdentifiersQuery();
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }

        /// <summary>
        /// Cadadastra um novo dispositivo na plataforma
        /// </summary>
        /// <param name="command">Detalhes do dispositivo sendo cadastrados</param>
        /// <returns>URL de acesso aos dados dispositivo recém cadastrado</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Register([FromBody] RegisterDeviceDto dto, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new RegisterDeviceCommand(
                dto.Identifier,
                dto.Description,
                dto.Manufacturer,
                dto.Url,
                dto.Commands), cancellationToken);

            return CreatedAtAction(nameof(GetDeviceByIdentifier), new { identifier = result.Value }, result.Value);
        }

        /// <summary>
        /// Obtém um dispositivo pelo identificador
        /// </summary>
        /// <param name="identifier">Identificador do dispositivo</param>
        /// <returns>O dispositivo correspondente ao identificador</returns>
        [HttpGet("{identifier}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDeviceByIdentifier(string identifier)
        {
            var query = new GetDeviceByIdentifierQuery(identifier);
            var device = await _sender.Send(query);
            if (device.Value == null) return NotFound();
            return Ok(device.Value);
        }

        /// <summary>
        /// Atualiza os dados de um dispositivo
        /// </summary>
        /// <param name="identifier">Identificador do dispositivo para o qual os detalhes devem ser atualizados</param>
        /// <param name="command">Detalhes atualizados do dispositivo</param>
        /// <returns>O dispositivo atualizado</returns>
        [HttpPut("{identifier}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateDevice(string identifier, [FromBody] UpdateDeviceDto dto)
        {
            if (identifier != dto.Identifier) return BadRequest();
            var command = new UpdateDeviceCommand(dto.Identifier, dto.Description, dto.Manufacturer, dto.Url, dto.Commands);
            var updatedDevice = await _sender.Send(command);
            if (updatedDevice.Value == null) return NotFound();
            return Ok(updatedDevice.Value);
        }

        /// <summary>
        /// Remove os detalhes de um dispositivo
        /// </summary>
        /// <param name="identifier">Identificador do dispositivo para o qual os detalhes devem ser removidos</param>
        /// <returns>Resultado da remoção</returns>
        [HttpDelete("{identifier}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteDevice(string identifier)
        {
            var command = new DeleteDeviceCommand(identifier);
            var result = await _sender.Send(command);
            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
