using Domain.Enums.Cliente;
using Domain.ValueObjetcs.Cliente;
using Entities = Domain.Entities;

namespace Application.Cliente.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Contrato { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPessoaFisica { get; set; }

        public static Entities.Cliente MapToEntity(ClienteDTO clienteDTO)
        {
            return new Entities.Cliente
            {
                Id = clienteDTO.Id,
                Contrato = clienteDTO.Contrato,
                ClienteTypeId = new ClienteInfo
                {
                    Endereco = clienteDTO.Endereco,
                    Bairro = clienteDTO.Bairro,
                    CEP = clienteDTO.CEP,
                    Telefone = clienteDTO.Telefone,
                    EmpresaInfo = (EmpresaInfo)clienteDTO.IdEmpresa,
                    PessoaFisicaInfo = (PessoaFisicaInfo)clienteDTO.IdPessoaFisica
                }
            };
        }
    }
}
