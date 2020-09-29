using Navita.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Navita.Core.Notificacoes
{
    public class Notificador : INotifier
    {
        private List<Notificacao> _notificacoes;
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }
        public List<Notificacao> GetNotificacoes()
        {
            return _notificacoes;
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public bool HasNotifcation()
        {
            return _notificacoes.Any();
        }
    }
}
