using Microsoft.EntityFrameworkCore;
using ProfProject.Data.Contexts;
using ProfProject.Entidades;
using ProfProject.Interfaces.Repositorios;
using ProfProject.Models;

namespace ProfProject.Data.Repositorios
{
    public class ProfessorRepositorio : Repositorio<Professor>, IProfessorRepositorio
    {
        public ProfessorRepositorio(SQLContext context) : base(context)
        {
        }

        public Paginacao<Professor> ObterTodosPorFiltro(Guid? materiaId, DayOfWeek? diaDaSemana, TimeSpan? horaDispInicio, TimeSpan? horaDispFim, int pagina, int limite)
        {
            
            var query = DbSet.Include(professor => professor.Materias)
                            .Include(professor => professor.DiasDaSemana)
                            .Where(DeletadoExpression);

            if (materiaId.HasValue) query.Where(professor => professor.Materias.Exists(materia => materia.Id == materiaId));
            if (diaDaSemana.HasValue) query.Where(professor => professor.DiasDaSemana.Exists(dia => dia.DiaSemana == diaDaSemana));
            if (horaDispInicio.HasValue) query.Where(professor => professor.DiasDaSemana.Exists(dia => dia.HoraDispInicio >= horaDispInicio));
            if (horaDispFim.HasValue) query.Where(professor => professor.DiasDaSemana.Exists(dia => dia.HoraDispFim <= horaDispFim));

            var total = query.Count();

            var data = query.ToList();

            return new Paginacao<Professor>(data, pagina, total, limite);

        }
    }
}
