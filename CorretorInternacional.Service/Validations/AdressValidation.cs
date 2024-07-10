using CorretorInternacional.Domain.Models;

using FluentValidation;

namespace CorretorInternacional.Service.Validations
{
    public class AdressValidation : AbstractValidator<Adress>
    {
        public AdressValidation()
        {
            RuleFor(Adress => Adress.AdressName)
                .NotEmpty().WithMessage("O logradouro é obrigatório.")
                .MinimumLength(10).WithMessage("O logradouro deve ter no mínimo 3 caracteres.");

            RuleFor(Adress => Adress.City)
                .NotEmpty().WithMessage("A cidade é obrigatória.")
                .NotNull().WithMessage("A cidade deve ser válida.");

            RuleFor(Adress => Adress.State)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .NotNull().WithMessage("O estado deve ser válido.");

            RuleFor(Adress => Adress.PostalCode)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .NotNull().WithMessage("O CEP deve ser válido.");

            RuleFor(Adress => Adress.Number)
                .NotEmpty().WithMessage("O número é obrigatório.")
                .NotNull().WithMessage("O número deve ser válido.");


            RuleFor(Adress => Adress.Active)
                .NotNull().WithMessage("O status é obrigatório.")
                .NotEmpty().WithMessage("O status deve ser diferente de inativo.");

            // Outras regras de validação...
        }
    }
}
