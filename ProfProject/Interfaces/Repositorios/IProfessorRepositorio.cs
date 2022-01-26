using ProfProject.Entidades;
using ProfProject.Models;

namespace ProfProject.Interfaces.Repositorios
{
    public interface IProfessorRepositorio : IRepositorio<Professor>
    {
        Paginacao<Professor> ObterTodosPorFiltro(Guid? materiaId, DayOfWeek? diaDaSemana, TimeSpan? horaDispInicio, TimeSpan? horaDispFim, int pagina, int limite);
    }
}
