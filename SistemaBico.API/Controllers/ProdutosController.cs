using Microsoft.AspNetCore.Mvc;

namespace SistemaBico.API.Controllers
{
	[Route("[controller]")]
	public class ProdutosController : Controller
	{
		[Route("novo-produto")]
		public IActionResult Index()
		{
			return View("NovoProduto");
		}

		[Route("listar")]
		public IActionResult ExibirProdutos()
		{
			return View("ExibirProdutos");
		}

	}
}
