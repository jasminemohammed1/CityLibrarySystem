using CityLibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Configurations
{
    internal class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            #region Properties
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar").HasMaxLength(11);
            builder.Property(x => x.Address).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.MemberShipDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Status).HasConversion<string>()
                .HasColumnType("varchar")
                .HasMaxLength(9);



            builder.ToTable(tb =>
            {

                tb.HasCheckConstraint("ValidEmailCheck", "Email like '_%@_%._%'");
                tb.HasCheckConstraint("ValidPhoneCheck", "PhoneNumber not like '%[^0-9]%'");
            });
            #endregion

        }
    }
}
