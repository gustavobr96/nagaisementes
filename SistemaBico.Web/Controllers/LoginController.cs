using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaBico.Web.Models;
using SistemaBico.Web.Models.Configuration;
using SistemaBico.Web.Models.Reponse;
using SistemaBico.Web.Services;
using System.Text;

namespace SistemaBico.Web.Controllers
{
    public class LoginController : Controller
    {
        #region views
        [Route("login")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View("Register");
        }

        #endregion

        #region Call API
        [Authorize]
        public async Task<IActionResult> Logoff()
        {
            await new AuthenticateService().Logoff(HttpContext);
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        [HttpPost, AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Authenticate(Client model)
        {
            if (model.ValidateLogin())
            {
                ModelState.AddModelError(string.Empty, "Preencha o e-mail e a senha!");
                return View("index", model);
            }

            var user = new User
            {
                Email = model.Email,
                Password = model.Password
            };

            ConfigAPI api = new ConfigAPI();
            string url = api.UrlAPI + "token/CreateToken";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(json);

                if (loginResponse.Token == null)
                {
                    ModelState.AddModelError(string.Empty, "Usuario ou senha invalido(s)");
                    return View("index", model);
                }


                await new AuthenticateService().Login(HttpContext, loginResponse);
                return RedirectToAction("Index", "Professional", new { area = "" });
            }
        }

        [HttpPost, AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Post(Client model)
        {
            if (model.ValidateRegister())
            {
                ModelState.AddModelError(string.Empty, "Preencha os dados obrigatórios!");
                return View("index", model);
            }

            ConfigAPI api = new ConfigAPI();
            string url = api.UrlAPI + "client/Register";
            using (HttpClient htppClient = new HttpClient())
            {
                HttpResponseMessage response = htppClient.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<object>(json);

                if (result == null)
                    return RedirectToAction("Email", "Validator", new { area = "" });

                return RedirectToAction("ErrorPage", "Error", new { area = "" });
            }
        }

        #endregion

    }
}
