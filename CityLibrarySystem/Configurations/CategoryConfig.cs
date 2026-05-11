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
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            #region Properties
            builder.Property(x => x.Title).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(100);
            #endregion


        }
    }
}
