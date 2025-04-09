
using Domain.DomainEntities;

namespace Domain.Ports
{
    public interface IClienteRepository
    {
        Task<Cliente> GetCliente(); 
        Task<int> Save (Cliente cliente);
    }
}
