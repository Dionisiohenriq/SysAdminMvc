using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SysAdminMvc.Entities.Configuration;

public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
{
    public void Configure(EntityTypeBuilder<Equipe> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(30);
        builder.Property(s => s.Setor).IsRequired().HasMaxLength(20);
        
        builder.ToTable("Equipe");
    }
}