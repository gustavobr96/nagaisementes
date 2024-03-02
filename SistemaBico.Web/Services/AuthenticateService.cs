using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SistemaBico.Web.Models.Reponse;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SistemaBico.Web.Services
{
    public class AuthenticateService
    {
        public async Task Login(HttpContext ctx, LoginResponse user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Name", user.User.Name));
            claims.Add(new Claim("Email", user.User.Email));
            //claims.Add(new Claim("Perfil", user.User.Email));
            claims.Add(new Claim("Token", user.Token));
            claims.Add(new Claim("Id", user.User.Id.ToString()));
            claims.Add(new Claim("ClientId", user.User.ClientId.ToString()));

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(user.Token);
            var claimsToken = token.Claims;

            //if (claimsToken.Any(f => f.Type == ClaimTypesConst.Cadastro))
            //{
            //    claims.Add(new Claim("Administrator", "Adm"));
            //}

            var claimsIdentity =
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme
                    )
                );

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(8),
                IssuedUtc = DateTime.Now
            };


            await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
        }

        public async Task<HttpClient> TokenAuth(HttpContext ctx, HttpClient client)
        {
            var claims = ctx.User.Claims.FirstOrDefault(c => c.Type == "Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", claims.Value);
            return await Task.FromResult(client);
        }
        public async Task Logoff(HttpContext ctx)
        {
            await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public static string ObterClientIdLogado(HttpContext contexto)
        {
            var id = contexto.User.Claims.FirstOrDefault(f => f.Type == "ClientId");
            return id != null ? id.Value : Guid.Empty.ToString();
        }
    }
}
