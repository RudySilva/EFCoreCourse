using CourseEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEFCore.Course.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(c => c.Phone).HasColumnType("CHAR(10)");
            builder.Property(c => c.PostCode).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(c => c.State).HasColumnType("CHAR(3)").IsRequired();
            builder.Property(c => c.City).HasMaxLength(60).IsRequired();
            builder.Property(c => c.Email).HasColumnType("VARCHAR(80)");
            builder.HasIndex(i => i.Phone).HasName("idx_client_phone");
        }
    }
}
