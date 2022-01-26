using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ProfProject.Interfaces.UoW;

namespace ProfProject.Controllers
{
    [ApiController]
    public abstract class ControllerBaseApp : ControllerBase
    {

        protected readonly IMapper Mapper;
        private readonly IUnitOfWork _uoW;

        protected ControllerBaseApp(IMapper mapper, IUnitOfWork uoW)
        {
            Mapper = mapper;
            _uoW = uoW;
        }


        protected bool Commit() => _uoW.Commit();

        protected bool ModelValida(ValidationResult validationResult)
        {
            if (validationResult.IsValid) return true;

            var erros = validationResult.Errors.Select(error => error.ErrorMessage);
            AdicionarErrosModelState(erros);
            return false;
        }


        protected IActionResult RespostaPadrao(object obj = null)
        {
            if (ModelState.IsValid)
                return Ok(new { success = true, data = obj });
            

            return BadRequest(new { success = false, data = ModelErrorsListStrings() });
        }


        protected IEnumerable<string> ModelErrorsListStrings()
        {
            if (ModelState.IsValid) return new List<string>();

            return ModelState.SelectMany(t => t.Value.Errors).Select(error => error.ErrorMessage).ToList();
        }

        protected void AdicionarErrosModelState(IEnumerable<string> erros)
        {
            foreach (var erro in erros) ModelState.AddModelError("Validação", erro);
        }
    }

}