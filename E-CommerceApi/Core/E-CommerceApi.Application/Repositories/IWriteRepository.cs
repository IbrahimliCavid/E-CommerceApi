using E_CommerceApi.Domain.Entities.Common;

namespace E_CommerceApi.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);

        Task<bool> AddRangeAsync(List<T> modles);

        Task<bool> Remove(string id);

        bool Remove(T model);
        bool RemoveRange(List<T> models);

        bool Update(T model);

        Task<int> SaveAsync();
    }
}
