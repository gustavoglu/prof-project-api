using FluentValidation;
using ProfProject.ViewModels.Professores;

namespace ProfProject.Validations.Professores
{
    public class ProfessorValidation : AbstractValidator<ProfessorViewModel>
    {

        public ProfessorValidation()
        {
            NomeCompletoValidate();
            FotoUrlValidate();
            WhatsAppValidate();
            BiografiaValidate();
            MateriasValidate();
            DiasDaSemanaoValidate();
        }

        protected void NomeCompletoValidate() {
            RuleFor(professor => professor.NomeCompleto)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        protected void FotoUrlValidate() {

            RuleFor(professor => professor.FotoUrl)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500);
        }
        protected void WhatsAppValidate() {

            RuleFor(professor => professor.NomeCompleto)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
        }
        protected void BiografiaValidate() {

            RuleFor(professor => professor.NomeCompleto)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1000);
        }
        protected void MateriasValidate()
        {

            When(professor => professor.Materias != null && professor.Materias.Any(),
                                    () => RuleForEach(professor => professor.Materias).SetValidator(new ProfessorMateriaValidation()));

        }
        protected void DiasDaSemanaoValidate() {

            When(professor => professor.DiasDaSemana != null && professor.DiasDaSemana.Any(),
                                       () => RuleForEach(professor => professor.DiasDaSemana).SetValidator(new ProfessorDiaValidation()));
        }
    }
}
