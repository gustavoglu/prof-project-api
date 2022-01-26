using ProfProject.Entidades;

namespace ProfProject.ViewModels.Professores
{
    public class ProfessorViewModel
    {
        public ProfessorViewModel()
        {
            Materias = new();
            DiasDaSemana = new();
        }
        public ProfessorViewModel(string nomeCompleto, string fotoUrl, string whatsApp, string biografia, List<ProfessorMateriaViewModel> materias, List<ProfessorDiaViewModel> diasDaSemana)
        {
            NomeCompleto = nomeCompleto;
            FotoUrl = fotoUrl;
            WhatsApp = whatsApp;
            Biografia = biografia;
            Materias = materias ?? new();
            DiasDaSemana = diasDaSemana ?? new();
        }

        public string NomeCompleto { get; set; }
        public string FotoUrl { get; set; }
        public string WhatsApp { get; set; }
        public string Biografia { get; set; }

        public List<ProfessorMateriaViewModel> Materias { get; set; }
        public List<ProfessorDiaViewModel> DiasDaSemana { get; set; }
    }
}
