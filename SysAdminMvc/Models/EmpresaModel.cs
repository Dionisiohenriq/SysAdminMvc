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
        return new EmpresaModel
        {
            Id = model.Id,
            Name = model.Name,
            Country = model.Country,
            Equipes = model.Equipes?.Select(e => EquipeModel.ToModel(e)).ToList()
        };
    }
}