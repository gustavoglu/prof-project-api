using ProfProject.Data.Contexts;
using ProfProject.Interfaces.UoW;

namespace ProfProject.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SQLContext _context;
        public UnitOfWork(SQLContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
