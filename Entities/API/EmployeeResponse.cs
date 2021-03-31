using System;
using Entities.DTO;

namespace Entities.API
{
    public class EmployeeResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MemberId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public long Balance { get; set; }
        public DateTime Birthday { get; set; }
        public string FavoriteLocation { get; set; }
        public string Phone { get; set; }
    }
}
