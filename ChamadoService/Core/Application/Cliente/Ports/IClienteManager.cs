using Application.Cliente.Requests;
using Application.Cliente.Responses;

namespace Application.Cliente.Ports
{
    public interface IClienteManager
    {
        Task<ClienteResponse> CriarCliente(CriarClienteRequest request);
    }
}
