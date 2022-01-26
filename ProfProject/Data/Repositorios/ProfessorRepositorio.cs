using Microsoft.EntityFrameworkCore;
using ProfProject.Data.Contexts;
using ProfProject.Entidades;
using ProfProject.Interfaces.Repositorios;
using ProfProject.Models;
using System.Linq.Expressions;

namespace ProfProject.Data.Repositorios
{
    public class ProfessorRepositorio : Repositorio<Professor>, IProfessorRepositorio
    {
        public ProfessorRepositorio(SQLContext context) : base(context)
        {
        }

        public Paginacao<Professor> ObterTodosPorFiltro(Guid? materiaId, DayOfWeek? diaDaSemana, TimeSpan? horaDispInicio, TimeSpan? horaDispFim, int pagina, int limite)
        {
            IQueryable<Professor> query = DbSet;

            query.Include(professor => professor.Materias)
                            .Include(professor => professor.DiasDaSemana)
                            .Where(DeletadoExpression);

            if (materiaId.HasValue) query.Where(professor => professor.Materias.Any(materia => materia.Id == materiaId));// Exists(materia => materia.Id == materiaId));
            if (diaDaSemana.HasValue) query.Where(professor => professor.DiasDaSemana.Any(dia => dia.DiaSemana == diaDaSemana));
            if (horaDispInicio.HasValue) query.Where(professor => professor.DiasDaSemana.Any(dia => dia.HoraDispInicio >= horaDispInicio));
            if (horaDispFim.HasValue) query.Where(professor => professor.DiasDaSemana.Any(dia => dia.HoraDispFim <= horaDispFim));

            var total = query.Count();

            var data = query.ToList();

            return new Paginacao<Professor>(data, pagina, total, limite);

        }
    }
}
