using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SysAdminMvc.Entities;
using SysAdminMvc.Entities.Configuration;

namespace SysAdminMvc.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Equipe> Equipes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
        modelBuilder.ApplyConfiguration(new EquipeConfiguration());
        modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}