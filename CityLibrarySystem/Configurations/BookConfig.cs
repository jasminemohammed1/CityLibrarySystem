using CityLibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Configurations
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            #region Properties
            builder.Property(p => p.Title).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(p => p.Price).HasPrecision(6, 2);
            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("PublicationYearCheck", "PublicationYear between 1950 and YEAR(GETDATE())");
                tb.HasCheckConstraint("AvailableCopiesCheck", "AvailableCopies <= AvailableCopies");
           }
            );

            #endregion
            #region Relationships
            builder.HasOne(x => x.BookAuthor)
                .WithMany(x => x.AuthorBooks)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BookCategory)
                .WithMany(x => x.CategoryBooks)
                .HasForeignKey(x => x.CategoryId);

            #endregion


        }
    }
}
