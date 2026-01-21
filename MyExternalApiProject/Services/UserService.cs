using Models;
using MyExternalIntegrationApi.Models;
using MyExternalIntegrationApi.Repositories;

namespace MyExternalIntegrationApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Ahora solo inyectamos el repositorio
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            // Delegamos la obtención de datos al repositorio
            var users = await _userRepository.GetExternalUsersAsync();
            
            // Aplicamos nuestra "sinergia" de negocio
            foreach (var user in users) 
            {
                AssignRole(user);
            }
            return users;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            // El repositorio se encarga del HTTP, nosotros del rol
            var user = await _userRepository.GetExternalUserByIdAsync(id);
            if (user != null) 
            {
                AssignRole(user);
            }
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            // Delegación directa
            return await _userRepository.DeleteExternalUserAsync(id);
        }

        private void AssignRole(User user)
        {
            user.Role = user.Id switch
            {
                1 => Role.Admin,
                var x when x % 2 == 0 => Role.User,
                _ => Role.Guest
            };
        }
    }
}