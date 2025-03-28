using SysAdminMvc.Entities;
using SysAdminMvc.Entities.ValueObjects;

namespace SysAdminMvc.Models;

public class FuncionarioModel
{
    public string Nome { get; set; }
    public Email Email { get; set; }
    public EquipeModel Equipe { get; set; }
    public Guid EquipeId { get; set; }
    public Guid EmpresaId { get; set; }
    public EmpresaModel Empresa { get; set; }
    public Empresa EmpresaEntity { get; set; }
    public Equipe EquipeEntity { get; set; }
}