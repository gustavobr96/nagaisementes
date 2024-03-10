using Ardalis.Result;
using MediatR;
using Sistema.Bico.Domain.Command.Menu;
using Sistema.Bico.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.UseCases.Menus
{

    public class AtivarDesativarMenuCommandHandler : IRequestHandler<AtivarEDesativarMenuCommand, Result>
    {
        private readonly IMenuRepository _menuRepository;

        public AtivarDesativarMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Result> Handle(AtivarEDesativarMenuCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var menu = await _menuRepository.GetEntityById(request.MenuId);
                menu.AtivarDesativar();

                await _menuRepository.Update(menu);
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Error("Erro durante a operação.");
            }
        }
    }
}
