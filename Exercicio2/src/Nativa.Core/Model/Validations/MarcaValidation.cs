using FluentValidation;

namespace Navita.Core.Model.Validations
{
    public class MarcaValidation : AbstractValidator<Marca>
    {
        public MarcaValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(2, 50).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
