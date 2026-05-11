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
    internal class FineConfig : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            #region Properties
            builder.Property(x => x.Amount).HasPrecision(6, 2);
            builder.Property(x => x.IssueDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.FineStatus).HasConversion<string>().HasColumnType("varchar")
                 .HasMaxLength(9);
            #endregion
            #region Fine & Loan
            builder.HasOne(x => x.Loan)
                .WithOne(x => x.Fine)
                .HasForeignKey<Fine>(x => x.LoanId);
            #endregion
        }

    }
}
