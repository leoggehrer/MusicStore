using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Logic.Controllers
{
    internal abstract partial class GenericController<E, I>
    {
        #region Async-Methods
        public Task<int> CountAsync()
        {
            return Context.CountAsync<I, E>();
        }
        public virtual Task<I> GetByIdAsync(int id)
        {
            return Task.Run<I>(() =>
            {
                var result = default(E);
                var item = Set.SingleOrDefault(i => i.Id == id);

                if (item != null)
                {
                    result = new E();
                    result.CopyProperties(item);
                }
                return result;
            });
        }
        public virtual Task<IEnumerable<I>> GetAllAsync()
        {
            return Task.Run<IEnumerable<I>>(() =>
                Set.Select(i =>
                    {
                        var result = new E();

                        result.CopyProperties(i);
                        return result;
                    }));
        }
        public virtual Task<I> CreateAsync()
        {
            return Task.Run<I>(() => new E());
        }

        protected virtual Task BeforeInsertingAsync(I entity)
        {
            return Task.FromResult(0);
        }
        public virtual async Task<I> InsertAsync(I entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await BeforeInsertingAsync(entity);
            var result = await Context.InsertAsync<I, E>(entity);
            await AfterInsertedAsync(result);
            return result;
        }
        protected virtual Task AfterInsertedAsync(E entity)
        {
            return Task.FromResult(0);
        }

        protected virtual Task BeforeUpdatingAsync(I entity)
        {
            return Task.FromResult(0);
        }
        public virtual async Task UpdateAsync(I entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await BeforeUpdatingAsync(entity);
            var updateEntity = await Context.UpdateAsync<I, E>(entity);

            if (updateEntity != null)
            {
                await AfterUpdatedAsync(updateEntity);
            }
            else
            {
                throw new Exception("Entity can't find!");
            }
        }
        protected virtual Task AfterUpdatedAsync(E entity)
        {
            return Task.FromResult(0);
        }

        protected virtual Task BeforeDeletingAsync(int id)
        {
            return Task.FromResult(0);
        }
        public async Task DeleteAsync(int id)
        {
            await BeforeDeletingAsync(id);
            var item = await Context.DeleteAsync<I, E>(id);

            if (item != null)
            {
                await AfterDeletedAsync(item);
            }
        }
        protected virtual Task AfterDeletedAsync(E entity)
        {
            return Task.FromResult(0);
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveAsync();
        }
        #endregion Async-Methods
    }
}
