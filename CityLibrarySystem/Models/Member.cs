using CityLibrarySystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    internal class Member : BaseEntity
    {

        #region Properties
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } 
        public string Address { get; set; } = null!;
        public DateTime MemberShipDate { get; set; }
        public MemberStatus Status { get; set; }
        #endregion


    }
}
