using FluentValidation;
using SysAdminMvc.Entities;
using SysAdminMvc.Models;

namespace SysAdminMvc.Validations;

public class EmpresaValidator : AbstractValidator<Empresa>
{
    public EmpresaValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Country).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull();
    }
}

public class EmpresaModelValidator : AbstractValidator<EmpresaModel>
{
    public EmpresaModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Must not be empty.");
        RuleFor(x => x.Country).NotEmpty().NotNull().WithMessage("Must not be empty.");
    }
}