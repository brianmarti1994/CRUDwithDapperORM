using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDDapperORM.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }
    }
}
