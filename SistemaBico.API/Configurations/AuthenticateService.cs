using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Sistema.Bico.Domain.Response;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace SistemaBico.API.Configurations
{
    public class AuthenticateService
    {
        public async Task Login(HttpContext ctx, LoginResponse user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.User.Email));
            claims.Add(new Claim("Token", user.Token));
            claims.Add(new Claim("Id", user.User.Id.ToString()));

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(user.Token);
            var claimsToken = token.Claims;

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
    }
}
