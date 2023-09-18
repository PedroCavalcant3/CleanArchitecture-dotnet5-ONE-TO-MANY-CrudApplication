using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            // Define o nome da tabela no banco de dados
            builder.ToTable("Suppliers");

            // Define a chave primária
            builder.HasKey(s => s.Id);

            // Define a propriedade 'Name' como obrigatória e com no máximo 255 caracteres
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Define a propriedade 'Category' com no máximo 100 caracteres
            builder.Property(s => s.Category)
                .HasMaxLength(100);

            // Define o relacionamento entre Supplier e Product
            // Aqui você pode configurar o relacionamento como desejado
            // Por exemplo, se um fornecedor pode ter muitos produtos
             builder.HasMany(s => s.Products).WithOne(p => p.Supplier).HasForeignKey(p => p.SupplierId);

            builder.HasData(
               new Supplier
               {
                   Id = 1,
                   Name = "Fornecedor 1",
                   Category = "Categoria 1"
               },
               new Supplier
               {
                   Id = 2,
                   Name = "Fornecedor 2",
                   Category = "Categoria 2"
               }
           );
        }
    }
}
