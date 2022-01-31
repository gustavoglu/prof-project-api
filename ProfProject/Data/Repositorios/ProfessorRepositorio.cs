using Dapper;
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

            IQueryable<Professor> query = null;

            if (!materiaId.HasValue && !diaDaSemana.HasValue && !horaDispInicio.HasValue && !horaDispFim.HasValue)
                query =  DbSet.Include(professor => professor.Materias)
                            .Include(professor => professor.DiasDaSemana)
                            .Where(DeletadoExpression); 

            if (materiaId.HasValue && !diaDaSemana.HasValue && !horaDispInicio.HasValue &&  !horaDispFim.HasValue) 
                query = DbSet.Include(professor => professor.Materias)
                            .Include(professor => professor.DiasDaSemana)
                            .Where(DeletadoExpression)
                            .Where(professor => professor.Materias.Any(materia => materia.Id == materiaId));

            if (materiaId.HasValue && diaDaSemana.HasValue && !horaDispInicio.HasValue &&  !horaDispFim.HasValue)
                query = DbSet.Include(professor => professor.Materias)
                            .Include(professor => professor.DiasDaSemana)
                            .Where(DeletadoExpression)
                            .Where(professor => professor.Materias.Any(materia => materia.Id == materiaId))
                            .Where(professor => professor.DiasDaSemana.Any(dia => dia.DiaSemana == diaDaSemana));


            if (materiaId.HasValue && diaDaSemana.HasValue && horaDispInicio.HasValue  && !horaDispFim.HasValue)
                query = DbSet.Include(professor => professor.Materias)
                            .Include(professor => professor.DiasDaSemana)
                            .Where(DeletadoExpression)
                            .Where(professor => professor.Materias.Any(materia => materia.Id == materiaId))
                            .Where(professor => professor.DiasDaSemana.Any(dia => dia.DiaSemana == diaDaSemana))
                            .Where(professor => professor.DiasDaSemana.Any(dia => dia.HoraDispInicio >= horaDispInicio));



            if (materiaId.HasValue && diaDaSemana.HasValue && horaDispInicio.HasValue && horaDispFim.HasValue)
                query = DbSet.Include(professor => professor.Materias)
                            .Include(professor => professor.DiasDaSemana)
                            .Where(DeletadoExpression)
                            .Where(professor => professor.Materias.Any(materia => materia.Id == materiaId))
                            .Where(professor => professor.DiasDaSemana.Any(dia => dia.DiaSemana == diaDaSemana))
                            .Where(professor => professor.DiasDaSemana.Any(dia => dia.HoraDispInicio >= horaDispInicio))
                            .Where(professor => professor.DiasDaSemana.Any(dia => dia.HoraDispFim <= horaDispFim));


            var total = query.Count();

            var data = query.ToList();

            return new Paginacao<Professor>(data, pagina, total, limite);

        }
    }
}
