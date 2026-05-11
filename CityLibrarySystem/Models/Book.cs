using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    internal class Book : BaseEntity
    {

        #region Properties
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public int PublicationYear {  get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }

        #endregion
        #region Book - Author
        public int AuthorId { get; set; }
        public Author BookAuthor { get; set; } = null!;
        #endregion
        #region Book - Category
        public Category BookCategory { get; set; } = null!;
        public int CategoryId { get; set; }

        #endregion
        #region Book - MemberLoan
        public ICollection<MemberLoan> BookLoans { get; set; } = new HashSet<MemberLoan>();
        #endregion
    }
}
