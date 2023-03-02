using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Domain.Entidades;
using SistemaVenda.Helpers;
using SistemaVenda.Models;
using Application.Services.Interfaces;

namespace SistemaVenda.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUsuarioService _authenticate;
        protected IHttpContextAccessor HttpContextAccessor;

        public AccountController(IUsuarioService authenticate, IHttpContextAccessor httpContextAccessor)
        {
            _authenticate = authenticate;
            HttpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var register = new RegisterFormViewModel();
            return View(register);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterFormViewModel register)
        {

            var result = await _authenticate.RegisterUser(register.Email, register.Password);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt");
                return View(register);
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var login = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel login)
        {
            var result = await _authenticate.Authenticate(login.Email, login.Password);

            if (result)
            {

                var usuario = await _authenticate.Resgatar(login.Email, login.Password);

                /*HttpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Email);
                HttpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                HttpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);*/

                if (string.IsNullOrEmpty(login.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }

                return Redirect(login.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return View(login);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return RedirectToAction("Login", "Account");
        }

    }
}
