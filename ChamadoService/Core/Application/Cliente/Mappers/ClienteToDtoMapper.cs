using Application.Cliente.Dto;
using Entities = Domain.Entities;

namespace Application.Cliente.Mappers
{
    public static class ClienteToDtoMapper
    {
        public static ClienteDto ToDto(this Entities.Cliente entidade)
        {
            return new ClienteDto
            {
                Id = entidade.Id,
                Contrato = entidade.Contrato,
                Endereco = entidade.ClienteInfo.Endereco,
                Bairro = entidade.ClienteInfo.Bairro,
                CEP = entidade.ClienteInfo.CEP,
                Telefone = entidade.ClienteInfo.Telefone,
                EmpresaInfo = entidade.ClienteInfo.EmpresaInfo?.ToDto(),
                PessoaFisicaInfo = entidade.ClienteInfo.PessoaFisicaInfo?.ToDto()
            };
        }
    }
}
