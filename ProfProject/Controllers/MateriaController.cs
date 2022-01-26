using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfProject.Entidades;
using ProfProject.Interfaces.Repositorios;
using ProfProject.Interfaces.UoW;
using ProfProject.Validations.Materias;
using ProfProject.ViewModels.Materias;
using System.ComponentModel.DataAnnotations;

namespace ProfProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MateriaController : ControllerBaseApp
    {
        private readonly IMateriaRepositorio _repositorio;

        public MateriaController(IMateriaRepositorio repositorio, IUnitOfWork uow, IMapper mapper) : base(mapper, uow)
        {
            _repositorio = repositorio;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] MateriaViewModel model)
        {
            var validation = new MateriaValidation().Validate(model);

            bool modelValida = ModelValida(validation);

            if (!modelValida) return RespostaPadrao();

            var materia = Mapper.Map<Materia>(model);
            _repositorio.Inserir(materia);

            Commit();

            return RespostaPadrao();
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Atualizar( Guid id, [FromBody] MateriaViewModel model)
        {
            var validation = new MateriaValidation().Validate(model);

            bool modelValida = ModelValida(validation);

            if (!modelValida) return RespostaPadrao();

            var materia = Mapper.Map<Materia>(model);

            _repositorio.Atualizar(id, materia);
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

        [HttpGet("{id:Guid}")]
        public IActionResult ObterTodos(Guid id)
        {
            return RespostaPadrao(_repositorio.ObterPorId(id));
        }
    }
}
