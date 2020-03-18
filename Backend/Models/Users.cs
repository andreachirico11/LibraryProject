using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Users
    {
        public Users()
        {
            Loans = new HashSet<Loans>();
        }

        public long IdCustomer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] DateJoin { get; set; }
        public long? IsAdmin { get; set; }

        public virtual ICollection<Loans> Loans { get; set; }
    }
}
