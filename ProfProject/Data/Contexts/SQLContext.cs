using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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


        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(entry => entry.Entity is Entidade);
            var insercoes = entries.Where(entry => entry.State == EntityState.Added);
            var atualizacoes = entries.Where(entry => entry.State == EntityState.Modified);
            var delecoes = entries.Where(entry => entry.State == EntityState.Deleted);

            PreencheCamposInsercoes(insercoes);
            PreencheCamposAtualizacoes(atualizacoes);
            PreencheCamposDelecoes(delecoes);

            return base.SaveChanges();
        }

        private void PreencheCamposInsercoes(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                var entidade = (Entidade)entry.Entity;
                entidade.CriadoEm = DateTime.Now;
            }
        }

        private void PreencheCamposAtualizacoes(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                var entidade = (Entidade)entry.Entity;
                entidade.AtualizadoEm = DateTime.Now;
            }
        }

        private void PreencheCamposDelecoes(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                var entidade = (Entidade)entry.Entity;
                entidade.DeletadoEm = DateTime.Now;
                entidade.Deletado = true;
                entry.State = EntityState.Modified;
            }
        }

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
