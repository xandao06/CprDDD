using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Domain.Entities;

namespace Data
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
                .Property(x => x.GenericoInfo);
        }
    }
}
