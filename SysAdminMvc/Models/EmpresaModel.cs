using NuGet.Packaging;
using SysAdminMvc.Entities;

namespace SysAdminMvc.Models;

public record EmpresaModel
{
    public Guid? Id { get; private set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public ICollection<EquipeModel>? Equipes { get; set; }

    public static EmpresaModel ToModel(Empresa model)
    {
        var empresaModel = new EmpresaModel
        {
            Id = model.Id,
            Name = model.Name,
            Country = model.Country,
        };
        if (model.Equipes == null) return empresaModel;
        var funcionariosModelList = model.Equipes.Select(EquipeModel.ToModel).ToList();
        empresaModel.Equipes.AddRange(funcionariosModelList);
        return empresaModel;
    }
}