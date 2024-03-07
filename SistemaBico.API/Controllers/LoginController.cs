using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Generics.Entities;
using Sistema.Bico.Domain.Generics.Interfaces;
using Sistema.Bico.Domain.Response;
using SistemaBico.API.Configurations;
using SistemaBico.API.Dtos;
using System.Threading.Tasks;

namespace SistemaBico.API.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IToken _token;

        public LoginController(SignInManager<ApplicationUser> signInManager, IToken token)
        {
            _signInManager = signInManager;
            _token = token;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Authenticate(UserDto dto)
        {
            if (dto.ValidateLogin())
            {
                ModelState.AddModelError(string.Empty, "Preencha o e-mail e a senha!");
                return View("index", dto);
            }

            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var loginResponse = await _token.GerarJwt(dto.Email);
                await new AuthenticateService().Login(HttpContext, loginResponse);
                return RedirectToAction("listar", "Produtos", new { area = "" });

            }

            ModelState.AddModelError(string.Empty, "Senha ou E-mail inválidos.");
            return View("index", dto);
        }

        [Authorize]
        [Route("Logoff")]
        public async Task<IActionResult> Logoff()
        {
            await new AuthenticateService().Logoff(HttpContext);
            return RedirectToAction("Index", "Login", new { area = "" });
        }
    }
}
