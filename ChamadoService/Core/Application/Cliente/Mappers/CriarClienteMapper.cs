// Application/Cliente/Mappers/CriarClienteMapper.cs
using Application.Cliente.Dto;
using Entities = Domain.Entities;
using Domain.ValueObjects.Cliente;

namespace Application.Cliente.Mappers
{
    public static class CriarClienteMapper
    {
        public static Entities.Cliente ToDomain(this CriarClienteDto dto)
        {
            var empresaVo = dto.EmpresaInfo?.ToDomain();            // ext. method EmpresaInfoDto→VO
            var pessoaVo = dto.PessoaFisicaInfo?.ToDomain();        // ext. method PessoaFisicaInfoDto→VO

            var info = new ClienteInfo(
              empresaVo,
              pessoaVo,
              dto.Endereco,
              dto.Bairro,
              dto.CEP,
              dto.Telefone
            );

            // usa o construtor que não leva Id
            return new Entities.Cliente(dto.Contrato, info);
        }
    }
}
