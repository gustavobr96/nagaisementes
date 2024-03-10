using Ardalis.Result;
using AutoMapper;
using MediatR;
using Sistema.Bico.Domain.Command.Menu;
using Sistema.Bico.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.UseCases.Menus
{
    public class EditarMenuCommandHandler : IRequestHandler<EditarMenuCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;

        public EditarMenuCommandHandler(IMapper mapper,
            IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(EditarMenuCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingMenu = await _menuRepository.GetEntityById(request.Id);

                if (existingMenu == null)
                {
                    return Result.Error("Menu não encontrado.");
                }


                existingMenu.Atualizar(request.Nome);

                await _menuRepository.Update(existingMenu);

                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Error("Erro durante a operação.");
            }
        }
    }
}
