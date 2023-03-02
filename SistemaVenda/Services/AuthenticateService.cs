using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositorio.DAL;
using Domain.Entidades;
using SistemaVenda.Helpers;

namespace SistemaVenda.Services
{
    public class AuthenticateService : IAuthenticate
    {

        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        protected readonly ApplicationDbContext _context;

        public AuthenticateService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string email, string password)
        {

            var user = new Usuario
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return result.Succeeded;
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
