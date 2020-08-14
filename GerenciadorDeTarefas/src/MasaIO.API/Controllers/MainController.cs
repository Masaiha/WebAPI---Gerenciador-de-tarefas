using MasaIO.business.Interface.Validation;
using MasaIO.business.Model.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace MasaIO.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {

        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(Object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    data = _notificador.ObterNotificacoes().Select(m => m.Message)
                });
            }
        }

        protected ActionResult CustomResponse(ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid) NotificarErroModelStateInvalida(ModelState);
            return CustomResponse();
        }

        protected void NotificarErroModelStateInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var msgErro = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(msgErro);
            }

        }

        protected void NotificarErro(string msgErro)
        {
            _notificador.Handle(new Notificacao(msgErro));
        }
    }
}
