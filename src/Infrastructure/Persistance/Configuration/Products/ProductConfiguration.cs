﻿using UnitTestTutorial.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UnitTestTutorial.Persistence.Configuration.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(k => k.Id);
        }
    }
}