using Ardalis.Result;
using AutoMapper;
using MediatR;
using Sistema.Bico.Domain.Command.Fornecedor;
using Sistema.Bico.Domain.Command.Menu;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.UseCases.Menus
{

    public class RegistrarMenuHandler : IRequestHandler<AddMenuCommand, Result>
    {
        private readonly IMenuRepository _menuRepository;

        public RegistrarMenuHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Result> Handle(AddMenuCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var menu = new Menu { Nome = request.Nome };
                await _menuRepository.Add(menu);
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Error("Erro durante a operação.");
            }
        }
    }
}
