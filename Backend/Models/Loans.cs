using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Loans
    {
        public long IdLoan { get; set; }
        public byte[] DateStart { get; set; }
        public byte[] DateReturn { get; set; }
        public long IdCustomer { get; set; }
        public long IdBook { get; set; }

        public virtual Books IdBookNavigation { get; set; }
        public virtual Users IdCustomerNavigation { get; set; }
    }
}
