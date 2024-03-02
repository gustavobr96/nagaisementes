using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaBico.Web.Models.Configuration;
using SistemaBico.Web.Models.Filters;
using SistemaBico.Web.Models.Reponse;
using SistemaBico.Web.Services;
using System.Text;

namespace SistemaBico.Web.Controllers
{
    [Route("[controller]")]
    public class ProfessionalController : Controller
    {
        #region views
        public async Task<IActionResult> Index()
        {
            var filter = new FilterPaginatedProfessionalModel();
            var result = await GetProfessionalProfilePaginated(filter);

            var pagesSize = Math.Ceiling((decimal)result.CountRegister/filter.Take);
            result.PagesSize = (int)pagesSize;
            return View("index", result);
        }

        #endregion

        #region Call API

        [HttpPost("ProfessionalPage")]
        public async Task<IActionResult> ProfessionalPage(FilterPaginatedProfessionalModel filter)
        {
            var result = await GetProfessionalProfilePaginated(filter);
            result.Page = filter.Page;
            
            var pagesSize = Math.Ceiling((decimal)result.CountRegister / filter.Take);
            result.PagesSize = (int)pagesSize;
            return View("index", result);
        }

        [HttpPost]
        [Route("ProfessionalProfilePaginated")]
        public async Task<ProfessionalProfilePaginationResponse> ProfessionalProfilePaginated([FromBody] FilterPaginatedProfessionalModel model)
        {
            return await GetProfessionalProfilePaginated(model);
        }

        private async Task<ProfessionalProfilePaginationResponse> GetProfessionalProfilePaginated(FilterPaginatedProfessionalModel model)
        {
            ConfigAPI api = new ConfigAPI();
            string url = api.UrlAPI + "professional/GetProfessionalPaginated";
            using (HttpClient htppClient = new HttpClient())
            {
                var idClient = AuthenticateService.ObterClientIdLogado(HttpContext);

                var clientToken = await new AuthenticateService().TokenAuth(HttpContext, htppClient);
                HttpResponseMessage response = clientToken.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<ProfessionalProfilePaginationResponse>(json);

                return result;
            }
        }
        #endregion

    }
}
