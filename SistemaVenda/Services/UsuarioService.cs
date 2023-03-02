using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositorio.DAL;
using Domain.Entidades;
using SistemaVenda.Helpers;
using Application.Services.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class UsuarioService : IUsuarioService
    {

        protected readonly IAuthenticate _autenticate;
        protected ApplicationDbContext _context;

        public UsuarioService(IAuthenticate authenticate)
        {
            _autenticate = authenticate;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _autenticate.Authenticate(email, password);

            return result;
        }

        public async Task Logout()
        {
            await _autenticate.Logout();
        }

        public async Task<bool> RegisterUser(string email, string password)
        {

            var result = await _autenticate.RegisterUser(email, password);

            if(result)
            {
                await _autenticate.Authenticate(email, password);
                return result;
            }

            return false;
        }

        public async Task<Usuario> Resgatar(string email, string password)
        {
            var Senha = Criptografia.GetMd5Hash(password);

            var usuario = await _context.Usuarios.Where(p => p.Email == email).FirstOrDefaultAsync();

            return usuario;
        }

    }
}
