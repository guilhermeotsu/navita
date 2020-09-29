using Navita.Core.Notificacoes;
using System.Collections.Generic;

namespace Navita.Core.Interfaces
{
    public interface INotifier
    {
        bool HasNotifcation();
        List<Notificacao> GetNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
