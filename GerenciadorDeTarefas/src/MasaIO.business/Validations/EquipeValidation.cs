using FluentValidation;
using MasaIO.business.Validations.Messages;
using MasaIO.business.Model;

namespace MasaIO.business.Validations
{
    public class EquipeValidation : AbstractValidator<Equipe>
    {
        public EquipeValidation()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage(MensagemValidacao.campoObrigatorio)
                .Length(2, 100).WithMessage(MensagemValidacao.lengthMaximoEMinimo);

        }
    }
}
