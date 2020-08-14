using FluentValidation;
using MasaIO.business.Model;
using MasaIO.business.Validations.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasaIO.business.Validations
{
    public class TarefaValidation : AbstractValidator<Tarefa>
    {
        public TarefaValidation()
        {
            RuleFor(t => t.Titulo)
                .NotEmpty().WithMessage(MensagemValidacao.campoObrigatorio)
                .Length(3, 100).WithMessage(MensagemValidacao.lengthMaximoEMinimo);

            RuleFor(t => t.Descricao)
                .NotEmpty().WithMessage(MensagemValidacao.campoObrigatorio)
                .Length(3, 100).WithMessage(MensagemValidacao.lengthMaximoEMinimo);

        }
    }
}
