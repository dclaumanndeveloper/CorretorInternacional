using CorretorInternacional.Domain.Models;

using FluentValidation;

namespace CorretorInternacional.Service.Validations
{
    public class ImovelValidation : AbstractValidator<Imovel>
    {
        public ImovelValidation()
        {
            RuleFor(imovel => imovel.Name)
                .NotEmpty().WithMessage("O nome do imóvel é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.");

            RuleFor(imovel => imovel.Price)
                .NotEmpty().WithMessage("O preço é obrigatório.")
                .NotNull().WithMessage("O preço deve ser válido.");

            RuleFor(imovel => imovel.Active)
                .NotNull().WithMessage("O status é obrigatório.")
                .NotEmpty().WithMessage("O status deve ser diferente de inativo.");

            // Outras regras de validação...
        }
    }
}
