using MyExternalIntegrationApi.Models;
using System.Net.Http.Json;

namespace MyExternalIntegrationApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;

        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetExternalUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<User>>("https://jsonplaceholder.typicode.com/users") 
                   ?? Enumerable.Empty<User>();
        }

        public async Task<User?> GetExternalUserByIdAsync(int id)
        {
            try {
                return await _httpClient.GetFromJsonAsync<User>($"https://jsonplaceholder.typicode.com/users/{id}");
            } catch { return null; }
        }

        public async Task<bool> DeleteExternalUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/users/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}