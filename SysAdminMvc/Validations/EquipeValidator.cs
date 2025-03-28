using FluentValidation;
using SysAdminMvc.Entities;

namespace SysAdminMvc.Validations;

public class EquipeValidator : AbstractValidator<Equipe>
{
    public EquipeValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Nome).NotEmpty().NotNull();
        RuleFor(x => x.Setor).NotEmpty().NotNull();
        RuleFor(x => x.EmpresaId).NotNull();
    }
}