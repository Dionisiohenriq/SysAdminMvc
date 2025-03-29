using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysAdminMvc.Models;

namespace SysAdminMvc.Entities;

public class Empresa
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string Country { get; private set; }
    public ICollection<Equipe> Equipes { get; private set; }
    
    private Empresa()
    {
    }

    private Empresa(EmpresaModel model)
    {
        Id = Guid.NewGuid();
        Name = model.Name;
        Country = model.Country;
        Equipes = model.Equipes;
    }

    public static Empresa Create(EmpresaModel model)
    {
        if (string.IsNullOrEmpty(model.Name))
            throw new ArgumentNullException(nameof(model.Name));

        if (string.IsNullOrEmpty(model.Country))
            throw new ArgumentNullException(nameof(model.Country));

        return new Empresa(model);
    }
}