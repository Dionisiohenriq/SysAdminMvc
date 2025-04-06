using SysAdminMvc.Entities;
using SysAdminMvc.Entities.ValueObjects;

namespace SysAdminMvc.Models;

public record FuncionarioModel
{
    public Guid Id { get; private set; }
    public string Nome { get; set; }
    public Email Email { get; set; }
    public EquipeModel Equipe { get; set; }
    public Guid EquipeId { get; set; }

    public static FuncionarioModel ToModel(Funcionario entity)
    {
        return new FuncionarioModel
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Email = entity.Email,
            Equipe = EquipeModel.ToModel(entity.Equipe),
            EquipeId = entity.EquipeId
        };
    }
}