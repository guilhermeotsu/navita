using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Navita.Core.Interfaces;
using Navita.Core.Notificacoes;
using System;
using System.Linq;

namespace Nativa.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly IUser AppUser;
        private readonly INotifier _notifier;
        protected Guid UserId { get; set; } = Guid.Empty;
        protected bool UserAuthenticated { get; set; } = false;

        public MainController(
            IUser appUser,
            INotifier notifier
        )
        {
            _notifier = notifier;
            AppUser = appUser;

            if (appUser.IsAuthenicated())
            {
                UserId = appUser.GetUserId();
                UserAuthenticated = true;
            }
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotifierErroModelInvalid(modelState);

            return CustomResponse();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationIsValid())
            {
                return Ok(
                    new
                    {
                        success = true,
                        data = result
                    });
            }

            return BadRequest(
                new
                {
                    success = false,
                    errors = _notifier.GetNotificacoes().Select(m => m.Message)
                });
        }

        protected bool OperationIsValid() => !_notifier.HasNotifcation();

        protected void NotifierErroModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(p => p.Errors);

            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;

                NotifierError(errorMessage);
            }
        }

        protected void NotifierError(string erroMessage)
        {
            _notifier.Handle(new Notificacao(erroMessage));
        }
    }
}
