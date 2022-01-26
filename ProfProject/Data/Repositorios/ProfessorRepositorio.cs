using ProfProject.Data.Contexts;
using ProfProject.Entidades;
using ProfProject.Interfaces.Repositorios;

namespace ProfProject.Data.Repositorios
{
    public class ProfessorRepositorio : Repositorio<Professor>, IProfessorRepositorio
    {
        public ProfessorRepositorio(SQLContext context) : base(context)
        {
        }
    }
}
