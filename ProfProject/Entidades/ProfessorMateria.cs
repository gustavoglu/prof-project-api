namespace ProfProject.Entidades
{
    public class ProfessorMateria : Entidade
    {
        public ProfessorMateria()
        {

        }
        public ProfessorMateria(Guid professorId, Guid materiaId, decimal custoHora)
        {
            ProfessorId = professorId;
            MateriaId = materiaId;
            CustoHora = custoHora;
        }

        public Guid ProfessorId { get; set; }
        public Guid MateriaId { get; set; }
        public decimal CustoHora { get; set; }

        //EF

        public Professor Professor { get; set; }
        public Materia Materia { get; set; }
    }
}
