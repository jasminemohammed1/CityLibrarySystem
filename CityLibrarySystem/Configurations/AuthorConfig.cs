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
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            #region Properties
            builder.Property(x => x.FirstName).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.LastName).HasColumnType("varchar").HasMaxLength(20);
            #endregion

        }
    }
}
