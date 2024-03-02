using Microsoft.AspNetCore.Mvc;

namespace SistemaBico.API.Controllers
{
	[Route("[controller]")]
	public class LoginController : Controller
	{
		[Route("entrar")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
