using Application.Cliente.Dto;
using Domain.ValueObjects.Cliente;
using Entities = Domain.Entities;

namespace Application.Cliente.Mappers
{
    public static class ClienteDtoMapper
    {
        public static Entities.Cliente ToDomain(this ClienteDto clienteDto)
        {
            // 1) converte os sub‐Dtos em VOs
            var empresaVO = clienteDto.EmpresaInfo.ToDomain();
            var pessoaVO = clienteDto.PessoaFisicaInfo.ToDomain();

            // 2) monta o VO de primeiro nível
            var clienteInfo = new ClienteInfo(
                empresaVO,
                pessoaVO,
                clienteDto.Endereco,
                clienteDto.Bairro,
                clienteDto.CEP,
                clienteDto.Telefone
            );

            // 3) retorna a entidade
            return new Entities.Cliente(
                clienteDto.Id,
                clienteDto.Contrato,
                clienteInfo
            );
        }
    }
}
