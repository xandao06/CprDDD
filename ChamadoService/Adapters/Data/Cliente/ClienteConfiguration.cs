using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Domain.Entities;

namespace Data.Cliente
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Entities.Cliente>
    {
        public void Configure(EntityTypeBuilder<Entities.Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.ClienteInfo, ci =>
            {
                // 2) Dentro dele, mapeia cada sub‐VO
                ci.OwnsOne(x => x.EmpresaInfo, eb =>
                {
                    eb.Property(x => x.RazaoSocial)
                      .HasColumnName("RazaoSocial");
                    eb.Property(x => x.Fantasia)
                      .HasColumnName("Fantasia");
                    eb.Property(x => x.CNPJ)
                      .HasColumnName("CNPJ");
                    eb.Property(x => x.InscricaoEstadual)
                      .HasColumnName("InscricaoEstadual");
                });

                ci.OwnsOne(x => x.PessoaFisicaInfo, pb =>
                {
                    pb.Property(x => x.Nome)
                      .HasColumnName("Nome");
                    pb.Property(x => x.CPF)
                      .HasColumnName("CPF");
                });

                // 3) E por fim, os campos escalares do ClienteInfo
                ci.Property(x => x.Endereco)
                  .HasColumnName("Endereco");
                ci.Property(x => x.Bairro)
                  .HasColumnName("Bairro");
                ci.Property(x => x.CEP)
                  .HasColumnName("CEP");
                ci.Property(x => x.Telefone)
                  .HasColumnName("Telefone");
            });

            builder.Navigation(c => c.ClienteInfo)
                .IsRequired();
        }
    }
}
