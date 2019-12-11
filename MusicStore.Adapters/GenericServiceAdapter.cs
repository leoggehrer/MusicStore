using CommonBase.Extensions;
using MusicStore.Adapters.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Adapters
{
    class GenericServiceAdapter<TContract, TEntity> : Contracts.Client.IAdapterAccess<TContract>
        where TContract : Contracts.IIdentifiable
        where TEntity : TContract, Contracts.ICopyable<TContract>, new()
    {
        private static string Separator => ";";

        public string BaseUri
        {
            get;
        }
        public virtual string ExtUri
        {
            get;
        }

        public GenericServiceAdapter(string baseUri, string extUri)
        {
            BaseUri = baseUri;
            ExtUri = extUri;
        }

        public int Count()
        {
			var task = CountAsync();

			return task.Result;
        }

        public IEnumerable<TContract> GetAll()
        {
			var task = GetAllAsync();

			return task.Result;
        }

        public TContract GetById(int id)
        {
			var task = GetByIdAsync(id);

			return task.Result;
		}

		public TContract Create()
        {
            return new TEntity();
        }

        public TContract Insert(TContract entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TContract entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync()
        {
			using var client = GetClient(BaseUri);
			HttpResponseMessage response = await client.GetAsync(ExtUri + "/CountAsync");

			if (response.IsSuccessStatusCode)
			{
				string stringData = await response.Content.ReadAsStringAsync();

				return Convert.ToInt32(stringData);
			}
			else
			{
				string stringData = await response.Content.ReadAsStringAsync();
				string errorMessage = $"{response.ReasonPhrase}: {stringData}";

				System.Diagnostics.Debug.WriteLine("{0} ({1})", (int)response.StatusCode, errorMessage);
				throw new AdapterException((int)response.StatusCode, errorMessage);
			}
		}

		public async Task<IEnumerable<TContract>> GetAllAsync()
        {
			using (var client = GetClient(BaseUri))
			{
				HttpResponseMessage response = await client.GetAsync(ExtUri + "/GetAsync");

				if (response.IsSuccessStatusCode)
				{
					string stringData = await response.Content.ReadAsStringAsync();

					return JsonConvert.DeserializeObject<TEntity[]>(stringData) as IEnumerable<TContract>;
				}
				else
				{
					string stringData = await response.Content.ReadAsStringAsync();
					string errorMessage = $"{response.ReasonPhrase}: {stringData}";

					System.Diagnostics.Debug.WriteLine("{0} ({1})", (int)response.StatusCode, errorMessage);
					throw new AdapterException((int)response.StatusCode, errorMessage);
				}
			}
		}

		public async Task<TContract> GetByIdAsync(int id)
        {
			using (var client = GetClient(BaseUri))
			{
				HttpResponseMessage response = await client.GetAsync($"{ExtUri}/GetAsync/{id}");

				if (response.IsSuccessStatusCode)
				{
					string stringData = await response.Content.ReadAsStringAsync();

					return (TContract)JsonConvert.DeserializeObject<TEntity>(stringData);
				}
				else
				{
					string stringData = await response.Content.ReadAsStringAsync();
					string errorMessage = $"{response.ReasonPhrase}: {stringData}";

					System.Diagnostics.Debug.WriteLine("{0} ({1})", (int)response.StatusCode, errorMessage);
					throw new AdapterException((int)response.StatusCode, errorMessage);
				}
			}
		}

		public Task<TContract> CreateAsync()
        {
            return Task.Run(() => Create());
        }

        public async Task<TContract> InsertAsync(TContract entity)
        {
			entity.CheckArgument(nameof(entity));

			using (var client = GetClient(BaseUri))
			{
				int result = 0;
				string jsonData = JsonConvert.SerializeObject(entity);
				StringContent contentData = new StringContent(jsonData, Encoding.UTF8, MediaType);
				HttpResponseMessage response = await client.PostAsync(ExtUri + "/PostAsync", contentData);

				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

					Int32.TryParse(content, out result);
				}
				else
				{
					string errorMessage = $"{response.ReasonPhrase}: {await response.Content.ReadAsStringAsync()}";

					System.Diagnostics.Debug.WriteLine("{0} ({1})", (int)response.StatusCode, errorMessage);
					throw new AdapterException((int)response.StatusCode, errorMessage);
				}
				return await GetByIdAsync(result);
			}
		}

		public async Task UpdateAsync(TContract entity)
        {
			entity.CheckArgument(nameof(entity));

			using (var client = GetClient(BaseUri))
			{
				string jsonData = JsonConvert.SerializeObject(entity);
				StringContent contentData = new StringContent(jsonData, Encoding.UTF8, MediaType);
				HttpResponseMessage response = await client.PutAsync(ExtUri + "/PutAsync", contentData).ConfigureAwait(false);

				if (response.IsSuccessStatusCode == false)
				{
					string errorMessage = $"{response.ReasonPhrase}: {await response.Content.ReadAsStringAsync().ConfigureAwait(false)}";

					System.Diagnostics.Debug.WriteLine("{0} ({1})", (int)response.StatusCode, errorMessage);
					throw new AdapterException((int)response.StatusCode, errorMessage);
				}
			}
		}

		public async Task DeleteAsync(int id)
        {
			using (var client = GetClient(BaseUri))
			{
				HttpResponseMessage response = await client.DeleteAsync(ExtUri);
				if (response.IsSuccessStatusCode == false)
				{
					string errorMessage = $"{response.ReasonPhrase}: {await response.Content.ReadAsStringAsync()}";

					System.Diagnostics.Debug.WriteLine("{0} ({1})", (int)response.StatusCode, errorMessage);
					throw new AdapterException((int)response.StatusCode, errorMessage);
				}
			}
		}

		public void Dispose()
        {
        }

		#region Helpers
		protected static string MediaType => "application/json";
		protected HttpClient CreateClient(string baseAddress)
		{
			HttpClient client = new HttpClient();

			if (baseAddress.EndsWith(@"/") == false
				|| baseAddress.EndsWith(@"\") == false)
			{
				baseAddress = baseAddress + "/";
			}

			client.BaseAddress = new Uri(baseAddress);
			client.DefaultRequestHeaders.Accept.Clear();

			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue(MediaType));

			return client;
		}
		protected HttpClient GetClient(string baseAddress)
		{
			return CreateClient(baseAddress);
		}
		#endregion Helpers
	}
}
