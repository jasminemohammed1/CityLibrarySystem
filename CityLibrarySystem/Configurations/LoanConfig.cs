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
    internal class LoanConfig : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            #region Properties
            builder.Property(x => x.LoanDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.LoanStatus).HasConversion<string>()
                .HasColumnType("varchar")
                .HasMaxLength(9);
            #endregion
        }
    }
}
