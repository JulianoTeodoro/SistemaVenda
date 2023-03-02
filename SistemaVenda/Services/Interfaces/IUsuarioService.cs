using Domain.Entidades;

namespace Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> Authenticate(string email, string password);
        Task Logout();
        Task<bool> RegisterUser(string email, string password);
        Task<Usuario> Resgatar(string email, string password);
    }
}
