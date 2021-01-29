using ACM_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BL.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //--Arrange
            ProductRepository productRepository = new ProductRepository();
            Product expected = new Product(1) //create and set expected prouct instance
            {
                ProductName = "Bike",
                ProductDescription = "A Nice Bike",
                CurentPrice = 1.21M,
            };

            //--Act
            //create and set actual product as whats retrived from the ProductRepository retreival
            Product actual = productRepository.Retreieve(1);

            //--Assert
            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.CurentPrice, actual.CurentPrice);

        }
    }
}
