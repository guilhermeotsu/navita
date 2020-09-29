using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Navita.Core.Model;

namespace Nativa.Data.Context.Mappings
{
    public class PatrimonioMapping : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.ToTable("Patrimonios");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.NTombo)
                .ValueGeneratedOnAdd();
        }
    }
}
