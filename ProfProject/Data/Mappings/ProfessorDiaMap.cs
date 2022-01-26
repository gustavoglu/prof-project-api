using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfProject.Entidades;

namespace ProfProject.Data.Mappings
{
    public class ProfessorDiaMap : IEntityTypeConfiguration<ProfessorDia>
    {
        public void Configure(EntityTypeBuilder<ProfessorDia> builder)
        {
            builder.Property(professorDia => professorDia.DiaSemana)
                .HasConversion<string>()
                .HasMaxLength(50);
        }
    }
}
