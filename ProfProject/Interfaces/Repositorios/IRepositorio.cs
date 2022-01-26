using ProfProject.Entidades;
using ProfProject.Models;
using System.Linq.Expressions;

namespace ProfProject.Interfaces.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {
        void Inserir(T entity);
        void Atualizar(Guid id,T entity);
        void Deletar(Guid id);
        Paginacao<T> ObterTodos(int pagina, int limite);
        Paginacao<T> Pesquisar(Expression<Func<T, bool>> expression, int pagina, int limite);
        T ObterPorId(Guid id);

    }
}
