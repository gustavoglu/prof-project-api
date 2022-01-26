using FluentValidation;
using ProfProject.ViewModels.Materias;

namespace ProfProject.Validations.Materias
{
    public class MateriaValidation : AbstractValidator<MateriaViewModel>
    {
        public MateriaValidation()
        {
            NomeValidate();
        }
        protected void NomeValidate()
        {
            RuleFor(materia => materia.Nome)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
