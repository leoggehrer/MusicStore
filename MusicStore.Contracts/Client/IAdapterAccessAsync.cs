using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStore.Contracts.Client
{
    public partial interface IAdapterAccess<T>
    {
        #region Async-Methods
        Task<int> CountAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync();
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        #endregion Async-Methods
    }
}
