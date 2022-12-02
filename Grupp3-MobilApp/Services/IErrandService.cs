using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupp3_MobilApp.Models;
using Newtonsoft.Json;
using System.Net;

namespace Grupp3_MobilApp.Services
{
    public interface IErrandService
    {
        Task<ErrandModel> GetErrandByIdAsync(string id);
        Task<IEnumerable<ErrandModel>> GetErrandsFromTechnicianIdAsync(string id);
        Task<HttpStatusCode> UpdateStatusAsync(string errandId, string status);
    }

    public class ErrandService : IErrandService
    {
        private const string BaseUrl = "https://grupp3azurefunctions.azurewebsites.net/api";
        private readonly HttpClient _client;

        public ErrandModel Errand { get; set; }
        public List<ErrandModel> Errands { get; set; }

        public ErrandService()
        {
            _client = new HttpClient();
        }

        public async Task<ErrandModel> GetErrandByIdAsync(string id)
        {
            Errand = new ErrandModel();
            var uri = new Uri(string.Format($"{BaseUrl}/errand?id={id}", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Errand = JsonConvert.DeserializeObject<ErrandModel>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Errand;
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

        public async Task<HttpStatusCode> UpdateStatusAsync(string errandId, string status)
        {
            var errandStatus = new ChangeErrandStatusModel { ErrandId = errandId, Status = status.ToString() };
            var uri = new Uri(string.Format($"{BaseUrl}/errands?", string.Empty));

            var json = JsonConvert.SerializeObject(errandStatus);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(uri, content);

            return response.IsSuccessStatusCode ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }
    }
}
