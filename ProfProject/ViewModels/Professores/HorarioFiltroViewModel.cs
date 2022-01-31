namespace ProfProject.ViewModels.Professores
{
    public class HorarioFiltroViewModel
    {
        public HorarioFiltroViewModel(int hora)
        {
            Hora = hora;
        }

        public int Hora { get; set; }
    }
}