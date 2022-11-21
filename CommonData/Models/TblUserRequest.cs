using System;
using System.Collections.Generic;

#nullable disable

namespace CommonData.Models
{
    public partial class TblUserRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }

        public static IEnumerable<TblUserRequest> Tolist()
        {
            throw new NotImplementedException();
        }
    }
}
