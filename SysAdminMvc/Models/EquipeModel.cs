using SysAdminMvc.Entities;

namespace SysAdminMvc.Models;

public record EquipeModel
{
    public string Name { get; set; }
    public EmpresaModel Empresa { get; set; }
    public Guid EmpresaId { get; set; }
    public string Setor { get; set; }
    public Empresa EmpresaEntity { get; set; }
}