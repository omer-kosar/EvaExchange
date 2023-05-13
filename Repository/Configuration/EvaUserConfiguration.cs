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

            //seed data
            // builder.HasData(
            //    new IdentityRole
            //    {
            //        Name = "Manager",
            //        NormalizedName = "MANAGER"
            //    },
            //new IdentityRole
            //{
            //    Name = "Administrator",
            //    NormalizedName = "ADMINISTRATOR"
            //});
        }
    }
}
