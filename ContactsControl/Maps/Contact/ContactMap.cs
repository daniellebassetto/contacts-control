using ContactsControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsControl.Map
{
    public class ContactMap : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            builder.ToTable("contato");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User);

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

            builder.Property(x => x.Phone).HasColumnName("telefone");
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15);
            builder.Property(x => x.Phone).ValueGeneratedNever();

            builder.Property(x => x.UserId).HasColumnName("id_usuario");
            builder.Property(x => x.UserId).ValueGeneratedNever();
        }
    }
}