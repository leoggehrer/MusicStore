using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Adapters
{
    class GenericControllerAdapter<TContract, TEntity> : Contracts.Client.IAdapterAccess<TContract>
        where TContract : Contracts.IIdentifiable
        where TEntity : TContract, Contracts.ICopyable<TContract>, new()
    {
        public Contracts.Client.IControllerAccess<TContract> controller;

        public GenericControllerAdapter()
        {
            controller = Logic.Factory.Create<TContract>();
        }

        #region Sync-Methods
        public int Count()
        {
            return controller.Count();
        }

        public TContract Create()
        {
            return controller.Create();
        }

        public IEnumerable<TContract> GetAll()
        {
            return controller.GetAll();
        }

        public TContract GetById(int id)
        {
            return controller.GetById(id);
        }

        public TContract Insert(TContract entity)
        {
            var result = controller.Insert(entity);

            controller.SaveChanges();
            return result;
        }
        public void Update(TContract entity)
        {
            controller.Update(entity);
            controller.SaveChanges();
        }
        public void Delete(int id)
        {
            controller.Delete(id);
            controller.SaveChanges();
        }
        #endregion Sync-Methods

        #region Async-Methods
        public Task<int> CountAsync()
        {
            return controller.CountAsync();
        }

        public Task<IEnumerable<TContract>> GetAllAsync()
        {
            return controller.GetAllAsync();
        }

        public Task<TContract> GetByIdAsync(int id)
        {
            return controller.GetByIdAsync(id);
        }

        public Task<TContract> CreateAsync()
        {
            return controller.CreateAsync();
        }

        public async Task<TContract> InsertAsync(TContract entity)
        {
            var result = await controller.InsertAsync(entity);

            await controller.SaveChangesAsync();
            return result;
        }

        public async Task UpdateAsync(TContract entity)
        {
            await controller.UpdateAsync(entity);
            await controller.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await controller.DeleteAsync(id);
            await controller.SaveChangesAsync();
        }
        #endregion Async-Methods

        public void Dispose()
        {
            controller.Dispose();
        }
    }
}
