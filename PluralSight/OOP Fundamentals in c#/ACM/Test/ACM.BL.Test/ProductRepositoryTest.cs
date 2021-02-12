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

        [TestMethod]
        public void SaveTestValid()
        {

            //--Arrange
            ProductRepository productRepository = new ProductRepository();
            Product updatedProduct = new Product(1) //create and set expected prouct instance
            {
                ProductName = "Car",
                ProductDescription = "A Nice Car",
                CurentPrice = 18M,
                HasChanges = true
            };

            //--Act
            //create and set actual product as whats retrived from the ProductRepository retreival
            bool actual = productRepository.Save(updatedProduct);

            //--Assert
            Assert.AreEqual(true, actual);

        }

        [TestMethod]
        public void SaveTestMissingPrice()
        {

            //--Arrange
            ProductRepository productRepository = new ProductRepository();
            Product updatedProduct = new Product(1) //create and set expected prouct instance
            {
                ProductName = "Car",
                ProductDescription = "A Nice Car",
                CurentPrice = null,
                HasChanges = true
            };

            //--Act
            //create and set actual product as whats retrived from the ProductRepository retreival
            bool actual = productRepository.Save(updatedProduct);

            //--Assert
            Assert.AreEqual(false, actual);    
            
        }
    }
}
