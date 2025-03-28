using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SysAdminMvc.Data;
using SysAdminMvc.Entities;
using SysAdminMvc.Validations;

namespace SysAdminMvc.Extensions.Configuration;

public static class ServicesExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Equipe>, EquipeValidator>();
        services.AddFluentValidationAutoValidation();
    }
}