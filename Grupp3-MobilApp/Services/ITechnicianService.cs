using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Grupp3_MobilApp.Models;

namespace Grupp3_MobilApp.Services
{
    public interface ITechnicianService
    {
        Task<IEnumerable<TechnicianModel>> GetAllTechnicians();
    }

    public class TechnicianService : ITechnicianService
    {
        private const string BaseUrl = "https://grupp3azurefunctions.azurewebsites.net/api";

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public List<TechnicianModel> Technicians { get; set; }
        public TechnicianService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<IEnumerable<TechnicianModel>> GetAllTechnicians()
        {
            Technicians = new List<TechnicianModel>();

            var uri = new Uri(string.Format($"{BaseUrl}/technician/all", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Technicians = JsonSerializer.Deserialize<List<TechnicianModel>>(content, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Technicians;
        }
    }
}
