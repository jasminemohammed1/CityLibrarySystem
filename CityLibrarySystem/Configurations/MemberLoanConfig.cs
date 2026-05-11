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
    internal class MemberLoanConfig : IEntityTypeConfiguration<MemberLoan>
    {
        public void Configure(EntityTypeBuilder<MemberLoan> builder)
        {
            builder.HasKey(x => new { x.LoanId, x.MemberId, x.BookId });
        }
    }
}
