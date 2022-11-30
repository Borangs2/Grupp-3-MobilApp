using Newtonsoft.Json;
using System.Text;
using Grupp3_MobilApp.Models;
using System.Net;

namespace Grupp3_MobilApp.Services
{
    public interface ICommentService
    {
        Task<HttpStatusCode> SaveCommentAsync(CreateErrandCommentModel comment);
    }

    public class CommentService : ICommentService
    {
        private const string BaseUrl = "https://grupp3azurefunctions.azurewebsites.net/api";

        private readonly HttpClient _client;

        public CommentService()
        {
            _client = new HttpClient();
        }

        public async Task<HttpStatusCode> SaveCommentAsync(CreateErrandCommentModel comment)
        {
            var uri = new Uri(string.Format($"{BaseUrl}/comment/create", string.Empty));

            var json = JsonConvert.SerializeObject(comment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(uri, content);

            return response.IsSuccessStatusCode ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }
    }
}
