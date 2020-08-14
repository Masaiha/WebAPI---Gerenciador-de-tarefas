using FluentValidation;
using FluentValidation.Results;
using MasaIO.business.Interface.Validation;
using MasaIO.business.Model;
using MasaIO.business.Model.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasaIO.business.Service.Validation
{
    public abstract class BaseServiceValidation
    {
        private readonly INotificador _notificador;

        protected BaseServiceValidation(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string message)
        {
            _notificador.Handle(new Notificacao(message));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entity);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
