using FluentValidation;
using SysAdminMvc.Entities.ValueObjects;

namespace SysAdminMvc.Validations;

public class EmailValidation : AbstractValidator<Email>
{
    public EmailValidation()
    {
        RuleFor(x => x.Value).NotNull().NotEmpty().EmailAddress();
    }
}