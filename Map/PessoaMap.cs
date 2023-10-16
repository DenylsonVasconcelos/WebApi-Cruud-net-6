using APICrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICrud.Map
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(55)").IsRequired();
            builder.Property(x => x.Sobrenome).HasColumnType("varchar(55)").IsRequired();
            builder.Property(x => x.Idade).HasColumnType("integer").IsRequired();
            builder.Property(x => x.Profissao).HasColumnType("varchar(80)").IsRequired();

        }
    }
}


