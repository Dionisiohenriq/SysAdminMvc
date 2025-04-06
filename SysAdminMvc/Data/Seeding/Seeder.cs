using System.Collections.ObjectModel;
using NuGet.Packaging;
using SysAdminMvc.Entities;
using SysAdminMvc.Entities.ValueObjects;
using SysAdminMvc.Models;

namespace SysAdminMvc.Data.Seeding;

public static class Seeder
{
    public static async Task Seed(this IApplicationBuilder app)
    {
        var listEmpresas = new List<Empresa>();
        await using var scope = app.ApplicationServices.CreateAsyncScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();

        var equipeCollection = new List<Equipe>();
        var funcionarioCollection = new List<Funcionario>();

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
                        Name = "Wolks",
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
                foreach (var item in listEmpresas)
                {
                    for (var i = 0; i < 3; i++)
                    {
                        var empresa = EmpresaModel.ToModel(item);
                        var equipe = await context.Equipes.AddAsync(
                            Equipe.Create(
                                new EquipeModel
                                {
                                    Empresa = empresa,
                                    Nome = $"Equipe{i}",
                                    Setor = $"Setor{i}",
                                    EmpresaId = empresa.Id!.Value,
                                }));

                        var equipeModel = EquipeModel.ToModel(equipe.Entity);
                        equipeCollection.Add(equipe.Entity);

                        for (var j = 0; j < 3; j++)
                        {
                            var funcionario = await context.Funcionarios.AddAsync(
                                Funcionario.Create(
                                    new FuncionarioModel
                                    {
                                        Nome = $"Funcionario{j}",
                                        EquipeId = equipeModel.Id!.Value,
                                        Equipe = equipeModel,
                                        Email = Email.Create($"funcionario{j}@gmail.com"),
                                    }));
                            funcionarioCollection.Add(funcionario.Entity);
                        }

                        equipe.Entity.Funcionarios.AddRange(funcionarioCollection);
                        context.Equipes.Update(equipe.Entity);
                    }

                    item.Equipes.AddRange(equipeCollection);
                    context.Empresas.Update(item);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}