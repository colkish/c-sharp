using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    class Product
    {
        public Product()
        {
                
        }
        public Product(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        //? means allow nulls
        public decimal? CurentPrice { get; set; }

        public Boolean Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurentPrice == null) isValid = false;
            return isValid;
        }

        public Product Retreive(string ProductId)
        {

            return new Product();
        }

        public List<Product> Retreive()
        {

            return new List<Product>();
        }

        public Boolean Save()
        {
            return true ;
        }

    }
}
