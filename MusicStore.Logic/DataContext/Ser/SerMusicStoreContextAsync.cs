using System.Threading.Tasks;

namespace MusicStore.Logic.DataContext.Ser
{
    internal partial class SerMusicStoreContext
    {
        #region Async-Methods
        public override Task SaveAsync()
        {
            return Task.Run(() =>
            {
                SaveToSer(Genres);
                SaveToSer(Artists);
                SaveToSer(Albums);
                SaveToSer(Tracks);
            });
        }
        #endregion Async-Methods
    }
}
