using Microsoft.AspNetCore.Mvc;

namespace SistemaBico.Web.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
