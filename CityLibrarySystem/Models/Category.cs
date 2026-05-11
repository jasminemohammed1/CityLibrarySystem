using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    internal class Category : BaseEntity
    {
        #region Properties
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        #endregion

    }
}
