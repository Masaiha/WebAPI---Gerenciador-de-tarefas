using MasaIO.business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasaIO.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titulo)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(t => t.Estado)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(t => t.DataUltimaAlteracao)
                .HasColumnType("datetime");

            builder.ToTable("Taferas");
        }
    }
}
