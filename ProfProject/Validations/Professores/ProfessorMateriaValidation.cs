using FluentValidation;
using ProfProject.ViewModels.Professores;

namespace ProfProject.Validations.Professores
{
    public class ProfessorMateriaValidation : AbstractValidator<ProfessorMateriaViewModel>
    {
        public ProfessorMateriaValidation()
        {
            MateriaIdValidate();
            CustoHoraValidate();
        }

        protected void MateriaIdValidate()
        {
            RuleFor(professorMateria => professorMateria.MateriaId)
                .NotNull()
                .NotEmpty();
        }

        protected void CustoHoraValidate()
        {
            RuleFor(professorMateria => professorMateria.CustoHora)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }

    }
}
