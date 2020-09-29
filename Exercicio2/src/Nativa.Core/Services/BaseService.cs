using FluentValidation;
using FluentValidation.Results;
using Nativa.Core.Model;
using Navita.Core.Interfaces;
using Navita.Core.Notificacoes;

namespace Navita.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;
        
        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Base
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notificacao(message));
        }
    }
}
