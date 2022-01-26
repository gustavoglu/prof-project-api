using FluentValidation;
using ProfProject.ViewModels.Professores;

namespace ProfProject.Validations.Professores
{
    public class ProfessorDiaValidation : AbstractValidator<ProfessorDiaViewModel>
    {
        public ProfessorDiaValidation()
        {
            DiaSemanaValidate();
            HoraDispInicioValidate();
            HoraDispFimValidate();
        }

        protected void DiaSemanaValidate()
        {
            RuleFor(professorDia => professorDia.DiaSemana)
                .NotNull();
        }

        protected void HoraDispInicioValidate()
        {
            RuleFor(professorDia => professorDia.HoraDispInicio)
                .NotEmpty()
                .NotNull();
        }

        protected void HoraDispFimValidate()
        {
            RuleFor(professorDia => professorDia.HoraDispFim)
                .NotEmpty()
                .NotNull();
        }
    }
}
