using NuGet.Packaging;
using SysAdminMvc.Entities;

namespace SysAdminMvc.Models;

public record EquipeModel
{
    public Guid? Id { get; private set; }
    public string Nome { get; set; }
    public EmpresaModel Empresa { get; set; }
    public Guid EmpresaId { get; set; }
    public string Setor { get; set; }

    public static EquipeModel ToModel(Equipe entity)
    {
        var equipeModel = new EquipeModel
        {
            Id = entity.Id,
            EmpresaId = entity.EmpresaId,
            Setor = entity.Setor,
            Nome = entity.Nome
        };
        return equipeModel;
    }
}