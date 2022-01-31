namespace ProfProject.ViewModels.Professores
{
    public class MateriaFiltroViewModel
    {
        public MateriaFiltroViewModel(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}