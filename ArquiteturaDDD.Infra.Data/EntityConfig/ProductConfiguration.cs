using ArquiteturaDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaDDD.Infra.Data.EntityConfig
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>, IMapping
    {
        public ProductConfiguration()
        {
            HasKey(p => p.ProductId);

            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Price)
                .IsRequired();

            HasRequired(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientId);



        }
       
    }
}
