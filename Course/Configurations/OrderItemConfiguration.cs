using CourseEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEFCore.Course.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Quantity).HasDefaultValue(1).IsRequired();
            builder.Property(o => o.Price).IsRequired();
            builder.Property(o => o.Discount).IsRequired();
        }
    }
}
