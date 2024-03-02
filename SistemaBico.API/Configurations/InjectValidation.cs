using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Command.Validations;
using Sistema.Bico.Domain.Generics.Entities;
using Sistema.Bico.Domain.Generics.Interfaces;
using Sistema.Bico.Domain.Interface;
using Sistema.Bico.Domain.UseCases.Cliente;
using Sistema.Bico.Infra.Generics.Repository;
using Sistema.Bico.Infra.Repository;

namespace SistemaBico.API.Configurations
{
	public static class InjectNative
    {
        public static void AddInjectValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AddClientCommand>, AddClientCommandValidation>();
        }

        public static void AddInjectHandlers(this IServiceCollection services)
        {

            services.AddScoped<IRequestHandler<AddClientCommand, Unit>, RegisterClientCommandHandler>();
        }

        public static void AddInjectRepositorys(this IServiceCollection services)
        {
     
            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddScoped<IToken, Token>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IIdentityRepository, IdentityRepository>();
          
        }
    }
}
