using CourseEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEFCore.Course.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.StartedIn).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(o => o.Status).HasConversion<string>();
            builder.Property(o => o.DeliveryType).HasConversion<int>();
            builder.Property(o => o.Observation).HasColumnType("VARCHAR(512)");

            builder.HasMany(o => o.Items)
             .WithOne(o => o.Order)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
