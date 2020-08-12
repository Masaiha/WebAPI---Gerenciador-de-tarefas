using MasaIO.business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasaIO.Data.Mappings
{
    public class EquipeMapping : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.escudo)
                .HasColumnType("varchar(30000000)");

            builder.HasMany(e => e.Tarefas)
                .WithOne(t => t.Equipe)
                .HasForeignKey(t => t.EquipeId);

            builder.ToTable("Equipes");
        }
    }
}
