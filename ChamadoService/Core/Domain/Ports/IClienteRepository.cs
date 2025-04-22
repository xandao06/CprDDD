
using Domain.Entities;

namespace Domain.Ports
{
    public interface IClienteRepository
    {
        Task<Cliente> GetCliente(); 
        Task<int> Criar (Cliente cliente);
    }
}
