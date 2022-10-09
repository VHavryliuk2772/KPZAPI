using Domain.RepositoryInterfaces;
using Domain.Models;
using Persistance;

namespace Persistence.Repositories
{
    public class ManyToManyRepository<T> : GenericRepository<T>, IManyToManyRepository<T> where T : BaseModel
    {
        public ManyToManyRepository(ApplicationContext applicationContext) : base(applicationContext)
        { 
        }

        private IEnumerable<T> Except<TKey>(IEnumerable<T> items, IEnumerable<T> others, Func<T, TKey> getKey)
        {
            return items
                .GroupJoin(others, getKey, getKey, (item, tempItems) => new { item, tempItems })
                .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(T)))
                .Select(t => t.t.item);
        }

        public async Task UpdateManyToManyAsync<TKey>(IEnumerable<T> items, IEnumerable<T> others, Func<T, TKey> getKey)
        {
            _appContext.Set<T>().RemoveRange(Except(items, others, getKey));
            _appContext.Set<T>().AddRange(Except(others, items, getKey));
            await _appContext.SaveChangesAsync();
        }
    }
}
