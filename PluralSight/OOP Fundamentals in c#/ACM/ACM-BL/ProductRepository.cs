using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_BL
{
    public class ProductRepository
    {
        //method to return a product
        public Product Retreieve(int productId)
        {
            Product product = new Product(productId);
            
            if (productId == 1)
            {
                product.ProductName = "Bike"; 
                product.ProductDescription = "A Nice Bike";
                product.CurentPrice = 1.21M;
            };

            Object myObject = new Object();
            Console.WriteLine($"Object:{myObject.ToString()}");
            Console.WriteLine($"Product:{product.ToString()}") ;
            return product;
        }

        public bool Save(Product product)
        {

            bool success = true;

            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
                    {
                        //call an insert proc
                    }
                    else
                    {
                        //call an update proc
                    }

                }
                else
                {
                    success = false;
                }
            }
            return success;
        }

    }
}
