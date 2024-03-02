using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using Sistema.Bico.Infra.Context;
using Sistema.Bico.Infra.Generics.Repository;

namespace Sistema.Bico.Infra.Repository
{

	public class VendaRepository : RepositoryGenerics<Venda>, IVendaRepository
	{
		private readonly ContextBase _context;

		public VendaRepository(ContextBase context)
		{
			this._context = context;
		}
	}
}
