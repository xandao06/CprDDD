using Application.Cliente.DTO;
using Domain.ValueObjects.Cliente;

namespace Application.Cliente.Mappers
{
    public static class EmpresaInfoMapper
    {
        public static EmpresaInfo ToDomain(this EmpresaInfoDTO empresaInfoDTO)
        {
            if (empresaInfoDTO is null)
                return null;

            return new EmpresaInfo(
                empresaInfoDTO.CNPJ,
                empresaInfoDTO.RazaoSocial,
                empresaInfoDTO.Fantasia,
                empresaInfoDTO.InscricaoEstadual
            );
        }
    }
}
