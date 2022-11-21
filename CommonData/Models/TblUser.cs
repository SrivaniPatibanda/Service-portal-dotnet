using System;
using System.Collections.Generic;

#nullable disable

namespace CommonData.Models
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Pan { get; set; }
        public string ContactNo { get; set; }
        public string Dob { get; set; }
        public string ContactPreference { get; set; }
    }
}
