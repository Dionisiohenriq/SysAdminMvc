using SysAdminMvc.Entities.ValueObjects;
using SysAdminMvc.Models;

namespace SysAdminMvc.Entities;

public class Funcionario
{
    public Guid Id { get; init; }
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public Equipe Equipe { get; set; }
    public Guid EquipeId { get; set; }

    public Funcionario()
    {
    }

    private Funcionario(FuncionarioModel model)
    {
        Id = Guid.NewGuid();
        Nome = model.Nome;
        Email = model.Email;
        EquipeId = model.EquipeId;
    }

    public static Funcionario Create(FuncionarioModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Nome))
            throw new ArgumentNullException(nameof(model.Nome));

        if (string.IsNullOrEmpty(model.Email.Value))
            throw new ArgumentNullException(nameof(model.Email.Value));

        return new Funcionario(model);
    }
}