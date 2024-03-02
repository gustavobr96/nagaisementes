using FluentValidation;

namespace Sistema.Bico.Domain.Command.Validations
{
	public class AddClientCommandValidation : AbstractValidator<AddClientCommand>
    {
        public AddClientCommandValidation()
        {
            RuleFor(c => c.Email)
             .EmailAddress().WithMessage("E-mail é obrigatório")
             .Length(1, 100).WithMessage("Apenas de 1 a 100 caracteres");
         
        }      
    }
}
