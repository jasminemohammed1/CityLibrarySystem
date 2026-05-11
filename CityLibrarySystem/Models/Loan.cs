using CityLibrarySystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    internal class Loan : BaseEntity
    {
        #region Properties
        public DateTime LoanDate {  get; set; }
        public LoanStatus LoanStatus { get; set; }
        #endregion
    }
}
