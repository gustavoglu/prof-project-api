using ProfProject.Data.Contexts;
using ProfProject.Entidades;
using ProfProject.Interfaces.Repositorios;

namespace ProfProject.Data.Repositorios
{
    public class MateriaRepositorio : Repositorio<Materia>, IMateriaRepositorio
    {
        public MateriaRepositorio(SQLContext context) : base(context)
        {
        }
    }
}
