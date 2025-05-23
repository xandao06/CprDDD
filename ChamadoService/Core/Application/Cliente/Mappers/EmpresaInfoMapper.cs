using Application.Cliente.Dto;
using Domain.ValueObjects.Cliente;

namespace Application.Cliente.Mappers
{
    public static class EmpresaInfoMapper
    {
        public static EmpresaInfo ToDomain(this EmpresaInfoDto dto)
        {
            if (dto is null) return null;
            return new EmpresaInfo(dto.CNPJ, dto.RazaoSocial, dto.Fantasia, dto.InscricaoEstadual);
        }

        public static EmpresaInfoDto ToDto(this EmpresaInfo vo)
        {
            if (vo is null) return null;
            return new EmpresaInfoDto
            {
                RazaoSocial = vo.RazaoSocial,
                Fantasia = vo.Fantasia,
                CNPJ = vo.CNPJ,
                InscricaoEstadual = vo.InscricaoEstadual
            };
        }
    }
}
