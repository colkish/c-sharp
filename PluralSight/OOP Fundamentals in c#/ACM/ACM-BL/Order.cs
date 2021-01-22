using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_BL
{
    class Order
    {
        public Order()
        {

        }
        public Order(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; set; }

        //offsset contains timezones
        public DateTimeOffset? OrderDate { get; set; }

        public List<Order> Retreive()
        {

            return new List<Order>();
        }


        public bool Save()
        {

            return true;
        }

        public bool Validate()
        {
            var isValid = true;
            if (OrderDate == null) isValid = false;
            return isValid;
        }
    }
}
