using Microsoft.EntityFrameworkCore;
using ProfProject.Data.Contexts;
using ProfProject.Entidades;
using ProfProject.Interfaces.Repositorios;
using ProfProject.Models;
using System.Linq.Expressions;

namespace ProfProject.Data.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidade
    {
        protected DbSet<T> DbSet { get; set; }
        protected Expression<Func<T, bool>> DeletadoExpression
        {
            get

            {
                return entidade => entidade.Deletado == false;
            }

        }

        protected readonly SQLContext Context;
        public Repositorio(SQLContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        public void Atualizar(Guid id, T entity)
        {
            var entidade = ObterPorId(id);


            if (entidade == null) return;
            entity.Id = id;

            DbSet.Add(entity);
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;//this is for modiying/update existing entry
        }

        public void Deletar(Guid id)
        {
            var entidade = ObterPorId(id);
            DbSet.Remove(entidade);
        }

        public void Inserir(T entity)
        {
            DbSet.Add(entity);
        }

        public T ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(entity => entity.Id == id);
        }

        public Paginacao<T> ObterTodos(int pagina, int limite)
        {
            var total = DbSet.Where(DeletadoExpression).Count();
            var data = DbSet.Where(DeletadoExpression).Skip((pagina - 1) * limite).Take(limite).AsNoTracking().ToList();
            return new Paginacao<T>(data, pagina, total, limite);
        }

        public Paginacao<T> Pesquisar(Expression<Func<T, bool>> expression, int pagina, int limite)
        {
            var total = DbSet.Where(DeletadoExpression).Where( expression).Count();
            var data = DbSet.Where(DeletadoExpression).Where(expression).Skip((pagina - 1) * limite).Take(limite).AsNoTracking().ToList();
            return new Paginacao<T>(data, pagina, total, limite);
        }
    }
}
