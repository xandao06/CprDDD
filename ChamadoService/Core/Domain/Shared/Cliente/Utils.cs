using System.Text.RegularExpressions;

namespace Domain.Shared.Cliente
{
    public static class Utils
    {
        public static bool ValidateTelefone(string telefone)
        {
            // 1) Falha rápido se vier nulo ou vazio
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            // 2) Remove tudo que não for dígito
            var somenteDigitos = Regex.Replace(telefone, @"\D", "");

            // 3) Verifica quantidade de dígitos
            return somenteDigitos.Length is >= 10 and <= 11;
        }

        public static bool ValidateCEP(string cep)
        {
            // 2) Remove tudo que não for dígito
            var somenteDigitos = Regex.Replace(cep, @"\D", "");

            // 3) Verifica quantidade de dígitos
            return somenteDigitos.Length is >= 8 and <= 9;
        }

        public static bool ValidateCPF(string cpf)
        {
            // 2) Remove tudo que não for dígito
            var somenteDigitos = Regex.Replace(cpf, @"\D", "");

            // 3) Verifica quantidade de dígitos
            return somenteDigitos.Length is <= 11 and >= 11;

        }

        public static bool ValidateCNPJ(string cnpj)
        {
            // 2) Remove tudo que não for dígito
            var somenteDigitos = Regex.Replace(cnpj, @"\D", "");

            // 3) Verifica quantidade de dígitos
            return somenteDigitos.Length is >= 14 and <= 15;
        }

        public static bool ValidateInscricaoEstadual(string inscricaoEstadual)
        {
            // 2) Remove tudo que não for dígito
            var somenteDigitos = Regex.Replace(inscricaoEstadual, @"\D", "");

            // 3) Verifica quantidade de dígitos
            return somenteDigitos.Length is >= 8 and <= 12;
        }
    }
}
