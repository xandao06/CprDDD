using Application.Cliente.DTO;
using Domain.ValueObjects.Cliente;
using Entities = Domain.Entities;

namespace Application.Cliente.Mappers
{
    public static class ClienteMapper
    {
        public static Entities.Cliente ToDomain(this ClienteDTO clienteDTO)
        {
            // 1) converte os sub‐DTOs em VOs
            var empresaVO = clienteDTO.EmpresaInfo.ToDomain();
            var pessoaVO = clienteDTO.PessoaFisicaInfo.ToDomain();

            // 2) monta o VO de primeiro nível
            var clienteInfo = new ClienteInfo(
                empresaVO,
                pessoaVO,
                clienteDTO.Endereco,
                clienteDTO.Bairro,
                clienteDTO.CEP,
                clienteDTO.Telefone
            );

            // 3) retorna a entidade
            return new Entities.Cliente(
                clienteDTO.Id,
                clienteDTO.Contrato,
                clienteInfo
            );
        }
    }
}
