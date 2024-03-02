using Microsoft.EntityFrameworkCore;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Generics.Entities;
using Sistema.Bico.Domain.Interface;
using Sistema.Bico.Infra.Context;
using Sistema.Bico.Infra.Generics.Repository;
using System.Threading.Tasks;

namespace Sistema.Bico.Infra.Repository
{
    public class ClientRepository : RepositoryGenerics<Client>, IClientRepository
    {
        private readonly ContextBase _context;

        public ClientRepository(ContextBase context)
        {
            this._context = context;
        }

        // Return Client
        public async Task<ApplicationUser> GetClientFromEmail(string email)
        {
            return await _context.ApplicationUser
                 .Include(c => c.Client)
                 .FirstOrDefaultAsync(f => f.Email == email);
        }
        public async Task<ApplicationUser> GetClientByUserId(string id)
        {
            return await _context.ApplicationUser
                 .Include(c => c.Client)
                 .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
