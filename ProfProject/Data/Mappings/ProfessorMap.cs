using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfProject.Entidades;

namespace ProfProject.Data.Mappings
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.Property(professor => professor.NomeCompleto)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(professor => professor.FotoUrl)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(professor => professor.WhatsApp)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(professor => professor.Biografia)
                .HasMaxLength(1000)
                .IsRequired();


            builder.HasMany(professor => professor.Materias)
                .WithOne(professorMateria => professorMateria.Professor)
                .HasForeignKey(professorMateria => professorMateria.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(professor => professor.DiasDaSemana)
                .WithOne(professorDias => professorDias.Professor)
                .HasForeignKey(professorDias => professorDias.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
