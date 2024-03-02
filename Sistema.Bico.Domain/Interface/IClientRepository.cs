using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Generics.Entities;
using Sistema.Bico.Domain.Generics.Interfaces;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.Interface
{
    public interface IClientRepository : IGeneric<Client>
    {
        Task<ApplicationUser> GetClientFromEmail(string email);
        Task<ApplicationUser> GetClientByUserId(string id);
    }
}
