using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupp3_MobilApp.Models;
using Newtonsoft.Json;

namespace Grupp3_MobilApp.Services
{
    public interface IErrandService
    {
        Task<ErrandModel> GetErrandByIdAsync(string id);
        Task<IEnumerable<ErrandModel>> GetErrandsFromTechnicianIdAsync(string id);
    }

    public class ErrandService : IErrandService
    {
        private const string BaseUrl = "https://grupp3azurefunctions.azurewebsites.net/api";

        private readonly HttpClient _client;

        public ErrandModel Item { get; set; }
        public List<ErrandModel> Errands { get; set; }

        public ErrandService()
        {
            _client = new HttpClient();
        }

        public async Task<ErrandModel> GetErrandByIdAsync(string id)
        {
            Item = new ErrandModel();

            var uri = new Uri(string.Format($"{BaseUrl}/errand?id={id}", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<ErrandModel>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Item;
        }

        public async Task<IEnumerable<ErrandModel>> GetErrandsFromTechnicianIdAsync(string id)
        {
            Errands = new List<ErrandModel>();

            var uri = new Uri(string.Format($"{BaseUrl}/technicianErrand?id={id}", string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Errands = JsonConvert.DeserializeObject<List<ErrandModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Errands;
        }
    }
}
