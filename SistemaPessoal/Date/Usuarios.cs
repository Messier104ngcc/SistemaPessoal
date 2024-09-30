using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaPessoal.Date
{
    public class Usuarios : IEntityTypeConfiguration<Models.Usuarios>
    {
        public void Configure(EntityTypeBuilder<Models.Usuarios> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(t => t.UserId);

            builder.Property(t => t.Nome).HasColumnType("varchar(20)");
            builder.Property(t => t.UserName).HasColumnType("varchar(50)");
            builder.Property(t => t.Senha).HasColumnType("varchar(14)");
            builder.Property(t => t.ConfSenha).HasColumnType("varchar(14)");
        }

    }
}
