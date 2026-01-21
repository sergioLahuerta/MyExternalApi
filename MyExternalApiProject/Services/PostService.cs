using MyExternalIntegrationApi.Models;
using System.Net.Http.Json;

namespace MyExternalIntegrationApi.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Post>>("https://jsonplaceholder.typicode.com/posts") 
                   ?? Enumerable.Empty<Post>();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}