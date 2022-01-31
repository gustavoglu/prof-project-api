using System;
namespace ProfProject.ViewModels.Professores
{
    public class ProfessorFiltrosViewModel
    {
        public ProfessorFiltrosViewModel(List<MateriaFiltroViewModel> materias)
        {


            Dias = new List<DiaFiltroViewModel>();
            Horarios = new List<HorarioFiltroViewModel>();
            Materias = materias ?? new List<MateriaFiltroViewModel>();

            int horas = 24;

            for (int i = 0; i < horas; i++)
                Horarios.Add(new HorarioFiltroViewModel(i));

            var daysOfWeek = Enum.GetValues<DayOfWeek>();

            foreach (var dayOfWeek in daysOfWeek)
                Dias.Add(new DiaFiltroViewModel(dayOfWeek));


        }

        public List<DiaFiltroViewModel> Dias { get; set; }
        public List<MateriaFiltroViewModel> Materias { get; set; }
        public List<HorarioFiltroViewModel> Horarios { get; set; }
    }
}