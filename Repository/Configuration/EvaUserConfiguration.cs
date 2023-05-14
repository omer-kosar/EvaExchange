using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class EvaUserConfiguration : IEntityTypeConfiguration<EvaUser>
    {
        public void Configure(EntityTypeBuilder<EvaUser> builder)
        {
            builder.ToTable("EvaUser");

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.HasData(
                new EvaUser { Id = 1, FirstName = "John", LastName = "Doe", UserName = "johndoe", Email = "johndoe@email.com", UserPassword = "password123" },
                new EvaUser { Id = 2, FirstName = "Bob", LastName = "Smith", UserName = "bobsmith", Email = "bobsmith@email.com", UserPassword = "password789" },
                new EvaUser { Id = 3, FirstName = "Alice", LastName = "Johnson", UserName = "alicejohnson", Email = "alicejohnson@email.com", UserPassword = "password1011" }
                );
        }
    }
}
