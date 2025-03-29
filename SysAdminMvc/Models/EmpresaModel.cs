using SysAdminMvc.Entities;

namespace SysAdminMvc.Models;

public record EmpresaModel
{
    public string Name { get; set; }
    public string Country { get; set; }
    public ICollection<Equipe> Equipes { get; set; }
}