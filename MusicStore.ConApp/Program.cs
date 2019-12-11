using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.ConApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Copy async
            //await CopyDataFromToByLogicAdapterAsync(Logic.Factory.PersistenceType.Csv, Adapters.Factory.AdapterType.Service);
            // Copy sync		
            //CopyDataFromToByLogic(Logic.Factory.PersistenceType.Csv, Logic.Factory.PersistenceType.Db);

            // Output async
            //await PrintDataAdapterAsync(Adapters.Factory.AdapterType.Service);
            // Output sync
            //PrintDataLogic(Logic.Factory.PersistenceType.Db);
        }

        static void CopyDataFromToByLogic(Logic.Factory.PersistenceType source, Logic.Factory.PersistenceType target)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Logic.Factory.Persistence = target;
                using (var genreCpyCtrl = Logic.Factory.CreateGenreController())
                using (var artistCpyCtrl = Logic.Factory.CreateArtistController(genreCpyCtrl))
                using (var albumCpyCtrl = Logic.Factory.CreateAlbumController(genreCpyCtrl))
                using (var trackCpyCtrl = Logic.Factory.CreateTrackController(genreCpyCtrl))
                {
                    foreach (var item in genreCtrl.GetAll())
                    {
                        genreCpyCtrl.Insert(item);
                    }
                    genreCpyCtrl.SaveChanges();

                    foreach (var item in artistCtrl.GetAll())
                    {
                        artistCpyCtrl.Insert(item);
                    }
                    artistCpyCtrl.SaveChanges();

                    foreach (var item in albumCtrl.GetAll())
                    {
                        albumCpyCtrl.Insert(item);
                    }
                    albumCpyCtrl.SaveChanges();

                    foreach (var item in trackCtrl.GetAll())
                    {
                        trackCpyCtrl.Insert(item);
                    }
                    trackCpyCtrl.SaveChanges();
                }
            }
        }
        static async Task CopyDataFromToLogicAsync(Logic.Factory.PersistenceType source, Logic.Factory.PersistenceType target)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Logic.Factory.Persistence = target;
                using (var genreCpyCtrl = Logic.Factory.CreateGenreController())
                using (var artistCpyCtrl = Logic.Factory.CreateArtistController(genreCpyCtrl))
                using (var albumCpyCtrl = Logic.Factory.CreateAlbumController(genreCpyCtrl))
                using (var trackCpyCtrl = Logic.Factory.CreateTrackController(genreCpyCtrl))
                {
                    foreach (var item in await genreCtrl.GetAllAsync())
                    {
                        await genreCpyCtrl.InsertAsync(item);
                    }
                    await genreCpyCtrl.SaveChangesAsync();

                    foreach (var item in await artistCtrl.GetAllAsync())
                    {
                        await artistCpyCtrl.InsertAsync(item);
                    }
                    await artistCpyCtrl.SaveChangesAsync();

                    foreach (var item in await albumCtrl.GetAllAsync())
                    {
                        await albumCpyCtrl.InsertAsync(item);
                    }
                    await albumCpyCtrl.SaveChangesAsync();

                    foreach (var item in await trackCtrl.GetAllAsync())
                    {
                        await trackCpyCtrl.InsertAsync(item);
                    }
                    await trackCpyCtrl.SaveChangesAsync();
                }
            }
        }
        static void PrintDataLogic(Logic.Factory.PersistenceType source)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Console.WriteLine("Write all genres");
                foreach (var item in genreCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all artists");
                foreach (var item in artistCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all alben");
                foreach (var item in albumCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }

                Console.WriteLine("Write all tracks");
                foreach (var item in trackCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }
        static async Task PrintDataLogicAsync(Logic.Factory.PersistenceType source)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Console.WriteLine("Write all genres");
                foreach (var item in await genreCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all artists");
                foreach (var item in await artistCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all alben");
                foreach (var item in await albumCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }

                Console.WriteLine("Write all tracks");
                foreach (var item in await trackCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }

        static void CopyDataFromToByLogicAdapter(Logic.Factory.PersistenceType source, Adapters.Factory.AdapterType adapter)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.Create<Contracts.Persistence.IGenre>())
            using (var artistCtrl = Logic.Factory.Create<Contracts.Persistence.IArtist>())
            using (var albumCtrl = Logic.Factory.Create<Contracts.Persistence.IAlbum>())
            using (var trackCtrl = Logic.Factory.Create<Contracts.Persistence.ITrack>())
            {
                Adapters.Factory.Adapter = adapter;
                using (var genreCpyDac = Adapters.Factory.Create<Contracts.Persistence.IGenre>())
                using (var artistCpyDac = Adapters.Factory.Create<Contracts.Persistence.IArtist>())
                using (var albumCpyDac = Adapters.Factory.Create<Contracts.Persistence.IAlbum>())
                using (var trackCpyDac = Adapters.Factory.Create<Contracts.Persistence.ITrack>())
                {
                    foreach (var item in genreCtrl.GetAll())
                    {
                        genreCpyDac.Insert(item);
                    }

                    foreach (var item in artistCtrl.GetAll())
                    {
                        artistCpyDac.Insert(item);
                    }

                    foreach (var item in albumCtrl.GetAll())
                    {
                        albumCpyDac.Insert(item);
                    }

                    foreach (var item in trackCtrl.GetAll())
                    {
                        trackCpyDac.Insert(item);
                    }
                }
            }
        }
        static async Task CopyDataFromToByLogicAdapterAsync(Logic.Factory.PersistenceType source, Adapters.Factory.AdapterType adapter)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.Create<Contracts.Persistence.IGenre>())
            using (var artistCtrl = Logic.Factory.Create<Contracts.Persistence.IArtist>())
            using (var albumCtrl = Logic.Factory.Create<Contracts.Persistence.IAlbum>())
            using (var trackCtrl = Logic.Factory.Create<Contracts.Persistence.ITrack>())
            {
                Adapters.Factory.Adapter = adapter;
                using (var genreCpyCtrl = Adapters.Factory.Create<Contracts.Persistence.IGenre>())
                using (var artistCpyCtrl = Adapters.Factory.Create<Contracts.Persistence.IArtist>())
                using (var albumCpyCtrl = Adapters.Factory.Create<Contracts.Persistence.IAlbum>())
                using (var trackCpyCtrl = Adapters.Factory.Create<Contracts.Persistence.ITrack>())
                {
                    foreach (var item in await genreCtrl.GetAllAsync())
                    {
                        await genreCpyCtrl.InsertAsync(item);
                    }

                    foreach (var item in await artistCtrl.GetAllAsync())
                    {
                        await artistCpyCtrl.InsertAsync(item);
                    }

                    foreach (var item in await albumCtrl.GetAllAsync())
                    {
                        await albumCpyCtrl.InsertAsync(item);
                    }

                    foreach (var item in await trackCtrl.GetAllAsync())
                    {
                        await trackCpyCtrl.InsertAsync(item);
                    }
                }
            }
        }
        static void PrintDataAdapter(Adapters.Factory.AdapterType adapter)
        {
            Adapters.Factory.Adapter = adapter;
            using (var genreDac = Adapters.Factory.Create<Contracts.Persistence.IGenre>())
            using (var artistDac = Adapters.Factory.Create<Contracts.Persistence.IArtist>())
            using (var albumDac = Adapters.Factory.Create<Contracts.Persistence.IAlbum>())
            using (var trackDac = Adapters.Factory.Create<Contracts.Persistence.ITrack>())
            {
                Console.WriteLine("Write all genres");
                foreach (var item in genreDac.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all artists");
                foreach (var item in artistDac.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all alben");
                foreach (var item in albumDac.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }

                Console.WriteLine("Write all tracks");
                foreach (var item in trackDac.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }
        static async Task PrintDataAdapterAsync(Adapters.Factory.AdapterType adapter)
        {
            Adapters.Factory.Adapter = adapter;
            using (var genreDac = Adapters.Factory.Create<Contracts.Persistence.IGenre>())
            using (var artistDac = Adapters.Factory.Create<Contracts.Persistence.IArtist>())
            using (var albumDac = Adapters.Factory.Create<Contracts.Persistence.IAlbum>())
            using (var trackDac = Adapters.Factory.Create<Contracts.Persistence.ITrack>())
            {
                Console.WriteLine("Write all genres");
                foreach (var item in await genreDac.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all artists");
                foreach (var item in await artistDac.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all alben");
                foreach (var item in await albumDac.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }

                Console.WriteLine("Write all tracks");
                foreach (var item in await trackDac.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }

		static void CleanCsvData(string path)
		{
			foreach (var file in System.IO.Directory.GetFiles(path))
			{
				string text = System.IO.File.ReadAllText(file, Encoding.UTF8);
				StringBuilder sb = new StringBuilder();

				text.ToList().ForEach(c =>
				{
					if (Char.IsWhiteSpace(c))
						sb.Append(c);
					else if (Char.IsPunctuation(c))
						sb.Append(c);
					else if (Char.IsDigit(c) || Char.IsLetter(c) || c == ',' || c == '.' || c== '!')
						sb.Append(c);
					else
					{
						sb.Append('#');
					};
				});
				System.IO.File.WriteAllText(@"C:\Temp\CsvData\" + System.IO.Path.GetFileName(file), sb.ToString(), Encoding.UTF8);
			}
		}
    }
}

