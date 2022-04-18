using ResourceManagement.Contracts;

namespace ResourceManagement.Repositories
{
    public interface IUnitOfWork<TId> : IDisposable
    {
        IRepositoryAsync<T, TId> Repository<T>() where T : AuditableEntity<TId>;

        void Commit();

        Task<int> CommitAsync(CancellationToken cancellationToken);

        Task<int> CommitAndRemoveCacheAsync(CancellationToken cancellationToken, params string[] cacheKeys);

        Task Rollback();
    }
}
