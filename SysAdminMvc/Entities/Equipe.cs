using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysAdminMvc.Models;

namespace SysAdminMvc.Entities;

public class Equipe
{
    public Guid Id { get; init; }
    public string Nome { get; private set; }
    public virtual Empresa Empresa { get; private set; }
    public Guid EmpresaId { get; set; }
    public string Setor { get; private set; }
    public ICollection<Funcionario>? Funcionarios { get; private set; }

    private Equipe(EquipeModel model)
    {
        Id = Guid.NewGuid();
        Nome = model.Nome;
        EmpresaId = model.EmpresaId;
        Empresa = Empresa.Create(model.Empresa);
        Setor = model.Setor;
        Funcionarios = model.Funcionarios?.Select(e => Funcionario.Create(e)).ToList();
    }

    public Equipe()
    {
    }

    public static Equipe Create(EquipeModel model)
    {
        if (string.IsNullOrEmpty(model.Nome))
            throw new ArgumentException(nameof(model.Nome));

        if (string.IsNullOrEmpty(model.Setor))
            throw new ArgumentException(nameof(model.Setor));

        return new Equipe(model);
    }
}