using SistemaVenda.Entidades;

namespace SistemaVenda.Services
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task Logout();
        Task<bool> RegisterUser(string email, string password);
        Task<Usuario> Resgatar(string email, string password);
    }
}
