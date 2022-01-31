using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfProject.Entidades;
using ProfProject.Interfaces.Repositorios;
using ProfProject.Interfaces.UoW;
using ProfProject.Validations.Professores;
using ProfProject.ViewModels.Professores;

namespace ProfProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfessorController : ControllerBaseApp
    {
        private readonly IProfessorRepositorio _repositorio;
        private readonly IMateriaRepositorio _materiaRepositorio;

        public ProfessorController(IMapper mapper, IUnitOfWork uoW, IProfessorRepositorio repositorio, IMateriaRepositorio materiaRepositorio) : base(mapper, uoW)
        {
            _repositorio = repositorio;
            _materiaRepositorio = materiaRepositorio;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] ProfessorViewModel model)
        {
            var validation = new ProfessorValidation().Validate(model);

            bool modelValida = ModelValida(validation);

            if (!modelValida) return RespostaPadrao();

            var entidade = Mapper.Map<Professor>(model);
            _repositorio.Inserir(entidade);

            Commit();

            return RespostaPadrao();
        }

        [HttpGet("filtros")]
        public IActionResult ObterFiltros()
        {
            var materias = _materiaRepositorio.ObterTodos(1, 1000).Data;
            var materiasFiltro = Mapper.Map<List<MateriaFiltroViewModel>>(materias);
            var professorFiltro = new ProfessorFiltrosViewModel(materiasFiltro);
            return RespostaPadrao(professorFiltro);
        }


        [HttpPut("{id:Guid}")]
        public IActionResult Atualizar(Guid id, [FromBody] ProfessorViewModel model)
        {
            var validation = new ProfessorValidation().Validate(model);

            bool modelValida = ModelValida(validation);

            if (!modelValida) return RespostaPadrao();

            var entidade = Mapper.Map<Professor>(model);
            _repositorio.Atualizar(id, entidade);

            Commit();

            return RespostaPadrao();
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Deletar(Guid id)
        {
            _repositorio.Deletar(id);
            Commit();
            return RespostaPadrao();
        }


        [HttpGet]
        public IActionResult ObterTodos(int pagina, int limite)
        {
            return RespostaPadrao(_repositorio.ObterTodos(pagina, limite));
        }

        [HttpGet("filtro")]
        public IActionResult ObterTodosPorFiltro(Guid? materiaId, DayOfWeek? diaDaSemana, TimeSpan? horaDispInicio, TimeSpan? horaDispFim, int pagina, int limite)
        {
            return RespostaPadrao(_repositorio.ObterTodosPorFiltro(materiaId, diaDaSemana, horaDispInicio, horaDispFim, pagina, limite));
        }

        [HttpGet("{id:Guid}")]
        public IActionResult ObterTodos(Guid id)
        {
            return RespostaPadrao(_repositorio.ObterPorId(id));
        }
    }
}
