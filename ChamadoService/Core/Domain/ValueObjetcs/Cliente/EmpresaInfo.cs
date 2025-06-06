﻿using Domain.Exceptions;
using Domain.Shared.Cliente;

namespace Domain.ValueObjects.Cliente
{
    public sealed class EmpresaInfo
    {
        public string CNPJ { get; private set; }
        public string RazaoSocial { get; private set; }
        public string Fantasia { get; private set; }
        public string InscricaoEstadual { get; private set; }

        //public string RazaoSocial { get; set; }
        //public string Fantasia { get; set; }
        //public string CNPJ { get; set; }
        //public string InscricaoEstadual { get; set; }

        private EmpresaInfo() { }
        public EmpresaInfo(string cnpj,
                       string razaoSocial,
                       string fantasia,
                       string inscricaoEstadual)
        {

            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            InscricaoEstadual = inscricaoEstadual;


            if (Utils.ValidateCNPJ(CNPJ) == false)
            {
                throw new MissingRequiredInformation("Digite um CNPJ válido");
            }

            if (Utils.ValidateInscricaoEstadual(InscricaoEstadual) == false)
            {
                throw new MissingRequiredInformation("Digite uma inscrição estadual válida");
            }

            
        }
    }

}
