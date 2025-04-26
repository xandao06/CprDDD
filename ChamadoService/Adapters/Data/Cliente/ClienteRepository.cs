
using Domain.Ports;

namespace Data.Cliente
{
    public class ClienteRepository : IClienteRepository
    {

        private CPRDbContext _cprDbContext;
        public ClienteRepository(CPRDbContext cprDbContext)
        {
            _cprDbContext = cprDbContext;
        }
        public async Task<int> Criar(Domain.Entities.Cliente cliente)
        {
            _cprDbContext.Clientes.Add(cliente);
            await _cprDbContext.SaveChangesAsync();
            return cliente.Id;
        }

        public Task<Domain.Entities.Cliente> GetCliente()
        {
            throw new NotImplementedException();
        }
    }
}
