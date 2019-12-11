using System;
using MusicStore.Contracts;

namespace MusicStore.Logic.Entities.Persistence
{
    /// <inheritdoc />
    /// <summary>
    /// Implements the properties and methods of track model.
    /// </summary>
    [Serializable]
    partial class Track : IdentityObject, Contracts.Persistence.ITrack, ICopyable<Contracts.Persistence.ITrack>
    {
        /// <inheritdoc />
        public int AlbumId { get; set; }
        /// <inheritdoc />
        public int GenreId { get; set; }
        /// <inheritdoc />
        public string Title { get; set; }
        /// <inheritdoc />
        public string Composer { get; set; }
        /// <inheritdoc />
        public long Milliseconds { get; set; }
        /// <inheritdoc />
        public long Bytes { get; set; }
        /// <inheritdoc />
        public double UnitPrice { get; set; }

        public void CopyProperties(Contracts.Persistence.ITrack other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Id = other.Id;
            AlbumId = other.AlbumId;
            GenreId = other.GenreId;
            Title = other.Title;
            Composer = other.Composer;
            Milliseconds = other.Milliseconds;
            Bytes = other.Bytes;
            UnitPrice = other.UnitPrice;
        }

		public Album Album { get; set; }
		public Genre Genre { get; set; }
    }
}
