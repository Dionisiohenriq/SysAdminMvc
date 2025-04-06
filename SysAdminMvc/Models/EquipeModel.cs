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
    public IList<FuncionarioModel>? Funcionarios { get; set; }

    public static EquipeModel ToModel(Equipe entity)
    {
        var equipeModel = new EquipeModel
        {
            Id = entity.Id,
            EmpresaId = entity.EmpresaId,
            Empresa = EmpresaModel.ToModel(entity.Empresa),
            Setor = entity.Setor,
            Nome = entity.Nome
        };

        if (entity.Funcionarios == null) return equipeModel;
        var funcionariosModelList = entity.Funcionarios.Select(FuncionarioModel.ToModel).ToList();
        equipeModel.Funcionarios.AddRange(funcionariosModelList);

        return equipeModel;
    }
}