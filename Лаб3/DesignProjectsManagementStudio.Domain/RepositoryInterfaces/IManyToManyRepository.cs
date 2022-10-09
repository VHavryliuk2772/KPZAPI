namespace Domain.RepositoryInterfaces
{
    public interface IManyToManyRepository<T> : IGenericRepository<T> where T : class
    {
        Task UpdateManyToManyAsync<TKey>(IEnumerable<T> currentSet, IEnumerable<T> newSet, Func<T, TKey> getKey);
    }
}
