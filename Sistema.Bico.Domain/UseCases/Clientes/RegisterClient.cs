using AutoMapper;
using MediatR;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Generics.Entities;
using Sistema.Bico.Domain.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.UseCases.Cliente
{
    public class RegisterClientCommandHandler : IRequestHandler<AddClientCommand, Unit>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IMapper _mapper;

        public RegisterClientCommandHandler(IIdentityRepository identityRepository,
            IMapper mapper)
        {
            _identityRepository = identityRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request);
            var identity = _mapper.Map<ApplicationUser>(request);

            // Set infos
            client.Email = identity.Email;
            identity.Client = client;

            await _identityRepository.RegisterAsync(identity, request.Password);
            return Unit.Value;
        }
    }
}
