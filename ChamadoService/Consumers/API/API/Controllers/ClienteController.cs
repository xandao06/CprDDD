using Application.Cliente.DTO;
using Application.Cliente.Ports;
using Application.Cliente.Requests;
using Microsoft.AspNetCore.Mvc;
using Application;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteManager _clienteManager;

        public ClienteController(
            ILogger<ClienteController> logger,
            IClienteManager clienteManager)
        {
            _logger = logger;
            _clienteManager = clienteManager;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Post(ClienteDTO cliente)
        {
            var request = new CriarClienteRequest
            {
                Data = cliente
            };

            var res = await _clienteManager.CriarCliente(request);

            if (res.Success) return Created("", res.Data);

            if (res.ErrorCode == ErrorCodes.NOT_FOUND)
            {
                return BadRequest(res);
            }
            else if (res.ErrorCode == ErrorCodes.INVALID_CLIENT_TYPE)
            {
                return BadRequest(res);
            }
            else if (res.ErrorCode == ErrorCodes.MISSING_REQUIRED_INFORMATION)
            {
                return BadRequest(res);
            }
            else if (res.ErrorCode == ErrorCodes.COULD_NOT_STORE_DATA)
            {
                return BadRequest(res);
            }

            _logger.LogError("Response with unknown ErrorCode Returned", res);
            return BadRequest(500);
        }

        //[HttpGet]
        //public async Task<ActionResult<GuestDto>> Get(int guestId)
        //{
        //    var res = await _guestManager.GetGuest(guestId);

        //    if (res.Success) return Ok(res.Data);

        //    return NotFound(res);
        //}
    }
}