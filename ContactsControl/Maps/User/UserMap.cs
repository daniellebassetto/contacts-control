using ContactsControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsControl.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Name).ValueGeneratedNever();

            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(256);
            builder.Property(x => x.Email).ValueGeneratedNever();

            builder.Property(x => x.TypeUser).HasColumnName("tipo_usuario");
            builder.Property(x => x.TypeUser).IsRequired();
            builder.Property(x => x.TypeUser).ValueGeneratedNever();

            builder.Property(x => x.Login).HasColumnName("login");
            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.Login).HasMaxLength(256);
            builder.Property(x => x.Login).ValueGeneratedNever();

            builder.Property(x => x.Password).HasColumnName("senha");
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100);
            builder.Property(x => x.Password).ValueGeneratedNever();

            builder.Property(x => x.RegistrationDate).HasColumnName("data_cadastro");
            builder.Property(x => x.RegistrationDate).IsRequired();
            builder.Property(x => x.RegistrationDate).ValueGeneratedNever();

            builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
            builder.Property(x => x.ChangeDate).ValueGeneratedNever();
        }
    }
}