using Microsoft.VisualBasic;
using MyExternalIntegrationApi.Models;
using System.Net.Http.Json;

namespace MyExternalIntegrationApi.Repositories
{
    public class PostRepository : IPostRepository
    {
        public string url = "https://jsonplaceholder.typicode.com/posts";
        private readonly HttpClient _httpClient;

        public PostRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Post>> GetExternalPostsAsync()
        {
            // Consumimos el endpoint de posts
            return await _httpClient.GetFromJsonAsync<IEnumerable<Post>>(url) 
                   ?? Enumerable.Empty<Post>();
        }

        public async Task<Post?> GetExternalPostByIdAsync(int id)
        {
            try 
            {
                return await _httpClient.GetFromJsonAsync<Post>($"{url}/posts/{id}");
            }
            catch (HttpRequestException)
            {
                // Si la API devuelve un 404 o error, retornamos null
                return null;
            }
        }

        public async Task<bool> DeleteExternalUserAsync(int id) // Asegúrate de que el nombre coincida con tu interfaz
        {
            var response = await _httpClient.DeleteAsync($"{url}/posts/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<bool> DeleteExternalPostAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}