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
            // sub‐DTOS → VOs
            var empresaVo = dto.EmpresaInfo?.ToDomain();
            var pessoaVo = dto.PessoaFisicaInfo?.ToDomain();

            // VO principal
            var info = new ClienteInfo(
                empresaVo, pessoaVo,
                dto.Endereco,
                dto.Bairro,
                dto.CEP,
                dto.Telefone);

            // usa o construtor (sem Id)
            return new Entities.Cliente(dto.Contrato, info);
        }
    }
}
