using Microsoft.EntityFrameworkCore;
using ProfProject.Data.Mappings;
using ProfProject.Entidades;

namespace ProfProject.Data.Contexts
{
    public class SQLContext : DbContext
    {

        private readonly IConfiguration _configuration;
        public SQLContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Materia> Materias { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<ProfessorDia> ProfessorDias{ get; set; }
        public DbSet<ProfessorMateria> ProfessorMaterias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MateriaMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new ProfessorDiaMap());


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("SQLite");

            optionsBuilder.UseSqlite(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
