namespace ProfProject.ViewModels.Professores
{
    public class DiaFiltroViewModel
    {
        public DiaFiltroViewModel(DayOfWeek dayOfWeek)
        {
            DayOfWeek = dayOfWeek;

            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    Dia = "Domingo";
                    break;
                case DayOfWeek.Monday:
                    Dia = "Segunda";
                    break;
                case DayOfWeek.Tuesday:
                    Dia = "Terça";
                    break;
                case DayOfWeek.Wednesday:
                    Dia = "Quarta";
                    break;
                case DayOfWeek.Thursday:
                    Dia = "Quinta";
                    break;
                case DayOfWeek.Friday:
                    Dia = "Sexta";
                    break;
                case DayOfWeek.Saturday:
                    Dia = "Sabado";
                    break;
                default:
                    Dia = null;
                    break;
            }

        }

        public DayOfWeek DayOfWeek { get; set; }
        public string Dia { get; set; }
    }
}