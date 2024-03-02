using Microsoft.AspNetCore.Identity;
using Sistema.Bico.Domain.Generics.Entities;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.Interface
{
    public interface IIdentityRepository
    {
        Task<IdentityResult> RegisterAsync(ApplicationUser identityUser, string password);
    }
}
