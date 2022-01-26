namespace ProfProject.Entidades
{
    public class ProfessorDia : Entidade
    {
        public ProfessorDia()
        {

        }
        public ProfessorDia(DayOfWeek diaSemana, TimeSpan horaDispInicio, TimeSpan horaDispFim, Guid professorId)
        {
            DiaSemana = diaSemana;
            HoraDispInicio = horaDispInicio;
            HoraDispFim = horaDispFim;
            ProfessorId = professorId;
        }

        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraDispInicio { get; set; }
        public TimeSpan HoraDispFim { get; set; }
        public Guid ProfessorId { get; set; }

        // EF

        public Professor Professor { get; set; }

    }
}
