namespace ProfProject.Entidades
{
    public class Professor : Entidade
    {
        public Professor()
        {

        }
        public string NomeCompleto { get; set; }
        public string FotoUrl { get; set; }
        public string WhatsApp { get; set; }
        public string Biografia { get; set; }

        // EF

        public List<ProfessorMateria> Materias { get; set; }
        public List<ProfessorDia> DiasDaSemana { get; set; }
    }
}
