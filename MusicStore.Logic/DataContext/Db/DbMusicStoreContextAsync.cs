using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Contracts;
using MusicStore.Logic.Entities;

namespace MusicStore.Logic.DataContext.Db
{
    partial class DbMusicStoreContext
    {
        #region IContext
		#region Async-Methods
		// Falls die synchronen Methoden entfernt werden soll,
		// dann werden diese private spezifiziert und aus dem 
		// Interface entfernt.
		public Task<int> CountAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I
        {
            return Set<E>().CountAsync();
        }
        public Task<E> CreateAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            return Task.Run(() => Create<I, E>());
        }
        public Task<E> InsertAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
			return Task.Run(() => Insert<I, E>(entity));
        }
        public Task<E> UpdateAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
			return Task.Run(() => Update<I, E>(entity));
        }
        public Task<E> DeleteAsync<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I
        {
			return Task.Run(() => Delete<I, E>(id));
        }
        public Task SaveAsync()
        {
            return Task.Run(() => base.SaveChangesAsync());
        }
        #endregion Async-Methods
        #endregion IContext
    }
}
