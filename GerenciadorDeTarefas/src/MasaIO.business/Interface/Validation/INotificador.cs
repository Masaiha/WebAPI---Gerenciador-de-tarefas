using MasaIO.business.Model.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasaIO.business.Interface.Validation
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
