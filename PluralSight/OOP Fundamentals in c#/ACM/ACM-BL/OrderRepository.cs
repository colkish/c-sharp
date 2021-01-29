using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_BL
{
    public class OrderRepository
    {
    
        //create the retreieve method
        public Order Retrieve(int OrderId)
        {

            Order order = new Order(1);

            if (order.OrderId == 1)
            {
                    order.OrderDate = new DateTimeOffset(DateTime.Now.Year,4,14,10,00,00, new TimeSpan(7,0,0));
            };

            return order;
        }

        public bool Save(Product product)
        {

            return true;
        }

    }
}
