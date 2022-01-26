namespace ProfProject.Entidades
{
    public class Materia : Entidade
    {
        public Materia()
        {

        }
        public Materia(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
