using FluentValidation;

namespace Navita.Core.Model.Validations
{
    public class PatrimonioCreateValidation : PatrimonioValidation
    {
        public PatrimonioCreateValidation()
        {
            RuleFor(p => p.NTombo)
                .Null().WithMessage("O campo NTombo não pode ser manipulado!");
        }
    }
}
