using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace ACM_BL
{
    public class Product : EntityBase
    {
        public Product()
        {
                
        }
        public Product(int productId)
        {
            ProductId = productId;
        }

        //short hand getter and setter, using a hidden backing field
        public int ProductId { get; private set; }

        //fully implemented getter and setter, defines the backing field
        private string _productName;
        public string ProductName 
        {
            get 
            {
                //why do we need to create an instance here can't we just return it, need to use a static class
                //StringHandler stringHandler = new StringHandler();
                //As it's static just refer to it
                return _productName.InsertSpaces();
            } 
            set
            { //need to add a refence as this is a re-usable component in a different project
                _productName = value;

            }

        }

        public string ProductDescription { get; set; }

        //? means allow nulls
        public decimal? CurentPrice { get; set; }

        public override string ToString() => ProductName;

        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurentPrice == null) isValid = false;
            return isValid;
        }
    }
}
