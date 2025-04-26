using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Domain.Entities;

namespace Data.Cliente
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Entities.Cliente>
    {
        public void Configure(EntityTypeBuilder<Entities.Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.ClienteTypeId);

            builder.OwnsOne(x => x.ClienteTypeId)
                .Property(x => x.EmpresaInfo);

            builder.OwnsOne(x => x.ClienteTypeId)
                .Property(x => x.PessoaFisicaInfo);

            builder.OwnsOne(x => x.ClienteTypeId)
                .Property(x => x.Endereco);

            builder.OwnsOne(x => x.ClienteTypeId)
                .Property(x => x.Bairro);

            builder.OwnsOne(x => x.ClienteTypeId)
                .Property(x => x.CEP);

            builder.OwnsOne(x => x.ClienteTypeId)
                .Property(x => x.Telefone);
        }
    }
}
