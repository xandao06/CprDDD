using Application.Cliente.DTO;
using Application.Cliente.Mappers;
using Application.Cliente.Ports;
using Application.Cliente.Requests;
using Application.Cliente.Responses;
using Domain.Exceptions;
using Domain.Ports;

namespace Application
{
    public class ClienteManager : IClienteManager
    {

        private IClienteRepository _clienteRepository;
        public ClienteManager(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<ClienteResponse> CriarCliente(CriarClienteRequest request)
        {
            try
            {
                var cliente = request.ClienteData.ToDomain();

                await cliente.Save(_clienteRepository);

                request.ClienteData.Id = cliente.Id;

                return new ClienteResponse
                {
                    ClienteData = request.ClienteData,
                    Success = true,
                };
            }

            catch (InvalidClientTypeException)
            {
                return new ClienteResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.INVALID_CLIENT_TYPE,
                    Message = "Tipo do cliente não pode ser nulo"
                };
            }

            catch (MissingRequiredInformation)
            {
                return new ClienteResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.MISSING_REQUIRED_INFORMATION,
                    Message = "Faltando informações necessárias"
                };
            }

            catch (Exception)
            {
                return new ClienteResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.COULD_NOT_STORE_DATA,
                    Message = "Ocorreu um erro ao salvar no banco"
                };
            }

        }
    }
}
