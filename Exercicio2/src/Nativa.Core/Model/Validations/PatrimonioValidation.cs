using FluentValidation;

namespace Navita.Core.Model.Validations
{
    public class PatrimonioValidation : AbstractValidator<Patrimonio>
    {
        public PatrimonioValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(3, 50).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength}");

            RuleFor(p => p.MarcaId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
