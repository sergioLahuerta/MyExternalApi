using MyExternalIntegrationApi.Models;

namespace MyExternalIntegrationApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetExternalUsersAsync();
        Task<User?> GetExternalUserByIdAsync(int id);
        Task<bool> DeleteExternalUserAsync(int id);
    }
}