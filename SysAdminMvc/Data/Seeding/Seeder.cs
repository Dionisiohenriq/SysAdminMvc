using SysAdminMvc.Entities;
using SysAdminMvc.Entities.ValueObjects;
using SysAdminMvc.Models;

namespace SysAdminMvc.Data.Seeding;

public static class Seeder
{
    public static async Task Seed(this IApplicationBuilder app)
    {
        var listEmpresas = new List<Empresa>();
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();

        if (context == null) return;
        await context.Database.EnsureCreatedAsync();

        // Empresas
        if (!context.Empresas.Any())
        {
            var brasil = await context.Empresas.AddAsync(
                Empresa.Create(
                    new EmpresaModel
                    {
                        Country = "Brasil",
                        Name = "GWM"
                    }));
            var argentina = await context.Empresas.AddAsync(
                Empresa.Create(
                    new EmpresaModel
                    {
                        Country = "Argentina",
                        Name = "Wolks"
                    }));
            var alemanha = await context.Empresas.AddAsync(
                Empresa.Create(
                    new EmpresaModel
                    {
                        Country = "Alemanha",
                        Name = "BMW"
                    }));

            listEmpresas.Add(brasil.Entity);
            listEmpresas.Add(argentina.Entity);
            listEmpresas.Add(alemanha.Entity);

            // Equipes
            if (!context.Equipes.Any())
            {
                for (var i = 0; i < listEmpresas.Count - 1; i++)
                {
                    var equipe = await context.Equipes.AddAsync(
                        Equipe.Create(
                            new EquipeModel
                            {
                                EmpresaEntity = listEmpresas[i],
                                Name = $"Equipe{i}",
                                Setor = $"Setor{i}",
                                EmpresaId = listEmpresas[i].Id,
                            }));

                    for (var j = 0; j < 3; j++)
                    {
                        var funcionario = context.Funcionarios.AddAsync(
                            Funcionario.Create(
                                new FuncionarioModel
                                {
                                    EmpresaId = listEmpresas[i].Id,
                                    Nome = $"Funcionario{j}",
                                    EquipeId = equipe.Entity.Id,
                                    EmpresaEntity = listEmpresas[i],
                                    EquipeEntity = equipe.Entity,
                                    Email = Email.Create($"Funcionario{j}@gmail.com"),
                                }));
                    }
                }
            }
        }
    }
}