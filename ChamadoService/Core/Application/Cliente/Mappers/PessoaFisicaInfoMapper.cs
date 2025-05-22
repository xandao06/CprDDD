using Application.Cliente.DTO;
using Domain.ValueObjects.Cliente;

namespace Application.Cliente.Mappers
{
    public static class PessoaFisicaInfoMapper
    {
        public static PessoaFisicaInfo ToDomain(this PessoaFisicaInfoDTO pessoaFisicaInfoDTO)
        {
            if (pessoaFisicaInfoDTO is null)
                return null;

            return new PessoaFisicaInfo(
                pessoaFisicaInfoDTO.Nome,
                pessoaFisicaInfoDTO.CPF
            );
        }
    }
}
