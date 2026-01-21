using Models;

namespace MyExternalIntegrationApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        
        // Añadimos el Rol usando las constantes que definiste
        public Role Role { get; set; } = Role.Guest;
    }
}