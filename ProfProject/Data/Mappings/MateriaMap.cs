using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfProject.Entidades;

namespace ProfProject.Data.Mappings
{
    public class MateriaMap : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.Property(materia => materia.Nome)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
