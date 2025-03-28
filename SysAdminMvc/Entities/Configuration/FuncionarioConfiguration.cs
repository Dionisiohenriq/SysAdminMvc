using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SysAdminMvc.Entities.Configuration;

public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
        builder.HasOne<Equipe>().WithMany().HasForeignKey(x => x.EquipeId).OnDelete(DeleteBehavior.Restrict);
        builder.Navigation(x => x.Equipe).IsRequired();

        builder.OwnsOne(e => e.Email,
            email => { email.Property(x => x.Value).HasColumnName("Email").IsRequired().HasMaxLength(100); });

        builder.ToTable("Funcionario");
    }
}