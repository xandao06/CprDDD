using Application.Cliente.Dto;
using Domain.ValueObjects.Cliente;

namespace Application.Cliente.Mappers
{
    public static class EmpresaInfoDtoMapper
    {
        public static EmpresaInfoDto ToDto(this EmpresaInfo vo)
        {
            if (vo is null) return null;
            return new EmpresaInfoDto
            {
                CNPJ = vo.CNPJ,
                RazaoSocial = vo.RazaoSocial,
                Fantasia = vo.Fantasia,
                InscricaoEstadual = vo.InscricaoEstadual
            };
        }
    }
}
