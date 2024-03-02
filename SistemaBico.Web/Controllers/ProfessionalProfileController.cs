using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaBico.Web.Enum;
using SistemaBico.Web.Models;
using SistemaBico.Web.Models.Configuration;
using SistemaBico.Web.Models.Filters;
using SistemaBico.Web.Models.Reponse;
using SistemaBico.Web.Services;
using SistemaBico.Web.Util;
using System.Text;

namespace SistemaBico.Web.Controllers
{
    [Route("[controller]")]
    public class ProfessionalProfileController : Controller
    {
        private readonly IMapper _mapper;

        public ProfessionalProfileController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region views


        [Route("CreateProfessionalProfile")]
        public async Task<IActionResult> CreateProfessionalProfile()
        {
            return View("CreateProfessionalProfile");
        }

        [Route("Plan")]
        public async Task<IActionResult> Plan()
        {
            var result = await GetProfissional();
            return result == null ? View("CreateProfessionalProfile") : View("Plan", result);
        }

        [Route("Address")]
        public async Task<IActionResult> Address()
        {
            var result = await GetProfissional();
            return result == null ? View("CreateProfessionalProfile") : View("Address", result);
        }

        [Route("account")]
        public async Task<IActionResult> Account()
        {
            var result = await GetProfissional();
            return result == null ? View("CreateProfessionalProfile") : View("Account", result);
        }


        [Route("callError")]
        public IActionResult CallError()
        {
            return RedirectToAction("ErrorPage", "Error", new { area = "" });
        }

        #endregion

        #region Call API
        [HttpGet("GetProfessional")]
        public async Task<ProfessionalProfileDto> GetProfessional()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    ConfigAPI api = new ConfigAPI();
                    var idClient = AuthenticateService.ObterClientIdLogado(HttpContext);
                    string url = api.UrlAPI + "professional/GetProfessionalProfileId/" + idClient;

                    var clientToken = await new AuthenticateService().TokenAuth(HttpContext, client);
                    var response = await clientToken.GetStringAsync(url);
                    var result = JsonConvert.DeserializeObject<ProfessionalProfileDto>(response);
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        [HttpGet("GetProfissionalEspeciality")]
        public async Task<ProfessionalProfileDto> GetProfissionalEspeciality()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    ConfigAPI api = new ConfigAPI();
                    var idClient = AuthenticateService.ObterClientIdLogado(HttpContext);
                    string url = api.UrlAPI + "professional/GetProfessionalProfileId/" + idClient;

                    var clientToken = await new AuthenticateService().TokenAuth(HttpContext, client);
                    var response = await clientToken.GetStringAsync(url);
                    var result = JsonConvert.DeserializeObject<ProfessionalProfileDto>(response);
                    result.Especiality = ListGeneric.GetProfessionalDynamicEspeciality(result.Especiality);
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Post(ProfessionalProfileDto model)
        {

            ConfigAPI api = new ConfigAPI();
            string url = api.UrlAPI + "professional/Register";
            using (HttpClient htppClient = new HttpClient())
            {
                var idClient = AuthenticateService.ObterClientIdLogado(HttpContext);

                var professionalProfile = _mapper.Map<ProfessionalProfile>(model);
                professionalProfile.ClientId = Guid.Parse(idClient);
                professionalProfile.AddressId = professionalProfile.Address.Id;

                var clientToken = await new AuthenticateService().TokenAuth(HttpContext, htppClient);
                HttpResponseMessage response = clientToken.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(professionalProfile), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<TypeStatusCode>(json);

                if (result == TypeStatusCode.Ok)
                    return RedirectToAction("Index", "Professional", new { area = "" });

                return RedirectToAction("ErrorPage", "Error", new { area = "" });
            }

        }

        [HttpPost]
        [Route("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(ProfessionalProfileDto model)
        {
            var result = await UpdateProfessional(model);

            if (result != null)
                return View("Account", result);

            return RedirectToAction("ErrorPage", "Error", new { area = "" });
        }


        [HttpPost]
        [Route("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(ProfessionalProfileDto model)
        {
            var result = await UpdateProfessional(model);

            if (result != null)
                return View("Address", result);

            return RedirectToAction("ErrorPage", "Error", new { area = "" });
        }


        private async Task<ProfessionalProfileDto> UpdateProfessional(ProfessionalProfileDto model)
        {
            ConfigAPI api = new ConfigAPI();
            string url = api.UrlAPI + "professional/Update";
            using (HttpClient htppClient = new HttpClient())
            {
                var idClient = AuthenticateService.ObterClientIdLogado(HttpContext);
                var professionalProfile = _mapper.Map<ProfessionalProfile>(model);
                professionalProfile.ClientId = Guid.Parse(idClient);

                var clientToken = await new AuthenticateService().TokenAuth(HttpContext, htppClient);
                HttpResponseMessage response = clientToken.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(professionalProfile), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<ProfessionalProfileDto>(json);

                return await Task.FromResult(result);
            }
        }

        private async Task<ProfessionalProfileDto> GetProfissional()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    ConfigAPI api = new ConfigAPI();
                    var idClient = AuthenticateService.ObterClientIdLogado(HttpContext);
                    string url = api.UrlAPI + "professional/GetProfessionalProfileId/" + idClient;

                    var clientToken = await new AuthenticateService().TokenAuth(HttpContext, client);
                    var response = await clientToken.GetStringAsync(url);
                    var result = JsonConvert.DeserializeObject<ProfessionalProfileDto>(response);
                    return await Task.FromResult(result);
                }
                catch (Exception ex)
                {
                    _ = CallError();
                    return null;
                }
            }
        }

        #endregion
    }
}
