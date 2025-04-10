using Application.Clientes.Requests;
using Application.Clientes.Responses;

namespace Application.Clientes.Ports
{
    public interface IClienteManager
    {
        Task<ClienteResponse> CriarCliente(CriarClienteRequest request);
    }
}
