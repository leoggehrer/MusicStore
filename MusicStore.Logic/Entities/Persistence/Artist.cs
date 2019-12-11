using System;
using System.Collections.Generic;
using MusicStore.Contracts;

namespace MusicStore.Logic.Entities.Persistence
{
	/// <inheritdoc />
	/// <summary>
	/// Implements the properties and methods of artist model.
	/// </summary>
	[Serializable]
    partial class Artist : IdentityObject, Contracts.Persistence.IArtist, ICopyable<Contracts.Persistence.IArtist>
    {
		/// <inheritdoc />
		public string Name { get; set; }

		public void CopyProperties(Contracts.Persistence.IArtist other)
		{
			if (other == null)
				throw new ArgumentNullException(nameof(other));

			Id = other.Id;
			Name = other.Name;
		}

		public IEnumerable<Album> Albums { get; set; }
	}
}