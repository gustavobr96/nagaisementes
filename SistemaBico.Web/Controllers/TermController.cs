using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaBico.Web.Models;
using SistemaBico.Web.Models.Configuration;
using SistemaBico.Web.Services;

namespace SistemaBico.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        [Route("GetTerm/{id}")]
        [HttpGet]
        public async Task<TermUse> GetId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                ConfigAPI api = new ConfigAPI();
                var idClient = AuthenticateService.ObterClientIdLogado(HttpContext);
                string url = api.UrlAPI + "term/GetTerm/" + id;

                var clientToken = await new AuthenticateService().TokenAuth(HttpContext, client);
                var response = await clientToken.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<TermUse>(response);
                return result;
            }
        }
    }
}
