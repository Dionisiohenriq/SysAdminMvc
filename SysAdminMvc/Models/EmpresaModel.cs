using NuGet.Packaging;
using SysAdminMvc.Entities;

namespace SysAdminMvc.Models;

public record EmpresaModel
{
    public Guid? Id { get; private set; }
    public string Name { get; set; }
    public string Country { get; set; }

    public static EmpresaModel ToModel(Empresa model)
    {
        var empresaModel = new EmpresaModel
        {
            Id = model.Id,
            Name = model.Name,
            Country = model.Country,
        };
        return empresaModel;
    }
}