using Domain.RepositoryInterfaces;
using Persistance;

namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext _context;

        public RepositoryManager(ApplicationContext context) => _context = context;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
