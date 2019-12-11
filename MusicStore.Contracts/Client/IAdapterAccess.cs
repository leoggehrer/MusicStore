using System;
using System.Collections.Generic;

namespace MusicStore.Contracts.Client
{
    public partial interface IAdapterAccess<T> : IDisposable
    {
        #region Sync-Methods
        int Count();
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create();
        T Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        #endregion Sync-Methods
    }
}
