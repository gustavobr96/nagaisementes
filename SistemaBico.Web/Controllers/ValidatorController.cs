using Microsoft.AspNetCore.Mvc;

namespace SistemaBico.Web.Controllers
{
    public class ValidatorController : Controller
    {
        [Route("email")]
        public IActionResult Email()
        {
            return View("Email");
        }
    }
}
