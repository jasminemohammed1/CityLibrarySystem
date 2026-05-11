using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    internal class Author : BaseEntity
    {
      #region Properties
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        #endregion
        #region Book-Author
        public ICollection<Book> AuthorBooks = new HashSet<Book>();
        #endregion
    }
}
