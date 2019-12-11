using System;
using System.Collections.Generic;
using MusicStore.Contracts;

namespace MusicStore.Logic.Entities.Persistence
{
	/// <inheritdoc />
	/// <summary>
	/// Implements the properties and methods of gener model.
	/// </summary>
	[Serializable]
    partial class Genre : IdentityObject, Contracts.Persistence.IGenre, ICopyable<Contracts.Persistence.IGenre>
    {
		/// <inheritdoc />
		public string Name { get; set; }

		public void CopyProperties(Contracts.Persistence.IGenre other)
		{
			if (other == null)
				throw new ArgumentNullException(nameof(other));

			Id = other.Id;
			Name = other.Name;
		}

		public IEnumerable<Track> Tracks { get; set; }
	}
}
