using Application.Cliente.Dto;
using Domain.ValueObjects.Cliente;

namespace Application.Cliente.Mappers
{
    public static class PessoaFisicaInfoMapper
    {
        public static PessoaFisicaInfo ToDomain(this PessoaFisicaInfoDto dto)
        {
            if (dto is null) return null;
            return new PessoaFisicaInfo(dto.Nome, dto.CPF);
        }

        public static PessoaFisicaInfoDto ToDto(this PessoaFisicaInfo vo)
        {
            if (vo is null) return null;
            return new PessoaFisicaInfoDto { Nome = vo.Nome, CPF = vo.CPF };
        }
    }
}
