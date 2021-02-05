using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_BL
{
    public class Order
    {
        public Order() : this(0)
        {

        }
        public Order(int orderId)
        {
            OrderId = orderId;
            OrderItems = new List<OrderItem>();
        }

        public int OrderId { get; private set; }

        //composition relationship to a order Id (has a) remember to initial the list  in the above constructors
        public List<OrderItem> OrderItems { get; set; }

        //offsset contains timezones
        public DateTimeOffset? OrderDate { get; set; }

        //collaborative rleationship (uses a) fk type reference here, as opposed to the way address was doen in custoer, where custoer contained address object
        public int CustomerId { get; set; }

        public int ShippingAddressId { get; set; }

        public bool Validate()
        {
            var isValid = true;
            if (OrderDate == null) isValid = false;
            return isValid;
        }
    }
}
