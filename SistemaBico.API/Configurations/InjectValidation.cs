using Ardalis.Result;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Command.Fornecedor;
using Sistema.Bico.Domain.Command.Menu;
using Sistema.Bico.Domain.Command.Produto;
using Sistema.Bico.Domain.Command.Validations;
using Sistema.Bico.Domain.Command.Venda;
using Sistema.Bico.Domain.Generics.Entities;
using Sistema.Bico.Domain.Generics.Interfaces;
using Sistema.Bico.Domain.Interface;
using Sistema.Bico.Domain.UseCases.Cliente;
using Sistema.Bico.Domain.UseCases.Fornecedores;
using Sistema.Bico.Domain.UseCases.Menus;
using Sistema.Bico.Domain.UseCases.Produtos;
using Sistema.Bico.Domain.UseCases.Vendas;
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
            services.AddScoped<IRequestHandler<AddProdutoCommand, Result>, RegistrarProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarVendaCommand, Result>, RegistrarVendaCommandHandler>();
            services.AddScoped<IRequestHandler<AddFornecedorCommand, Result>, RegistrarFornecedorHandler>();
            services.AddScoped<IRequestHandler<AtivarEDesativarProdutoCommand, Result>, AtivarDesativarProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarEDesativarMenuCommand, Result>, AtivarDesativarMenuCommandHandler>();
            services.AddScoped<IRequestHandler<EditarProdutoCommand, Result>, EditarProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<EditarFornecedorCommand, Result>, EditarFornecedorCommandHandler>();
            services.AddScoped<IRequestHandler<AddMenuCommand, Result>, RegistrarMenuHandler>();
            services.AddScoped<IRequestHandler<EditarMenuCommand, Result>, EditarMenuCommandHandler>();
        }

        public static void AddInjectRepositorys(this IServiceCollection services)
        {

            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddScoped<IToken, Token>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();

        }
    }
}
