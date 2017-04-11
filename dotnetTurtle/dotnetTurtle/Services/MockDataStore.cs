using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using dotnetTurtle.Models;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;

[assembly: Dependency(typeof(dotnetTurtle.Services.MockDataStore))]
namespace dotnetTurtle.Services
{   
    //Change IDataStore to Events
	public class MockDataStore : IDataStore<Events>
	{
		bool isInitialized;
        List<Events> events;

		public async Task<bool> AddItemAsync(Events item)
		{
			await InitializeAsync();

			events.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Events item)
		{
			await InitializeAsync();

			var _item = events.Where((Events arg) => arg.Id == item.Id).FirstOrDefault();
			events.Remove(_item);
			events.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Events item)
		{
			await InitializeAsync();

			var _item = events.Where((Events arg) => arg.Id == item.Id).FirstOrDefault();
			events.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Events> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(events.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Events>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(events);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}

		public async Task InitializeAsync()
		{
			if (isInitialized)
				return;

			events = new List<Events>();

            var json = DownloadJsonEvents();

            var _items = ConvertJSONToEvent(json);
			
			foreach (Events item in _items)
			{
                item.Id = Guid.NewGuid().ToString();
				events.Add(item);
			}

			isInitialized = true;
		}


        //MYSTUFF*************************************************************************************
        public string DownloadJsonEvents()
        {
            var json = new WebClient()
                .DownloadString("http://dotnetbcbackend.azurewebsites.net/api/APIPublicEvents");


            return json;
        }

        public List<Events> ConvertJSONToEvent(string json)
        {

            List<Events> evList = JsonConvert.DeserializeObject<List<Events>>(json);
            return evList;
        }
    }
}
