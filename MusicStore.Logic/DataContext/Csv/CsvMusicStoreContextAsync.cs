using System.Threading.Tasks;

namespace MusicStore.Logic.DataContext.Csv
{
    partial class CsvMusicStoreContext
    {
        #region Async-Methods
        public override Task SaveAsync()
        {
            return Task.Run(() =>
            {
                SaveToCsv(Genres);
                SaveToCsv(Artists);
                SaveToCsv(Albums);
                SaveToCsv(Tracks);
            });
        }
        #endregion Async-Methods
    }
}
