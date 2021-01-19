using ACM_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BL.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //--Arrange
            //define customer object as a new instance of type customer
            //the fact its a customer type is obvious, so as below we can use the var keyword
            Customer customer = new Customer
            {
                FirstName = "Colin",
                LastName = "Kish"
            };
            string expected = "Kish, Colin";

            //--Act
            string actual = customer.FullName;

            //--Type
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //--Arrange
            //define customer object as a new instance of type customer using the var keyword
            var customer = new Customer
            {
                LastName = "Kish"
            };
            string expected = "Kish";

            //--Act
            string actual = customer.FullName;

            //--Type
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //--Arrange
            var customer = new Customer
            {
                FirstName = "Colin"
            };
            string expected = "Colin";

            //--Act
            string actual = customer.FullName;

            //--Type
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameByReference()
        {
            //--Arrange
            var c1 = new Customer
            {
                FirstName = "Colin"
            };
            var c2 = c1; //objects are by reference so now both c1 nad c2 point to the same object

            //so if I set c2 first name, its changed for c1 also
            c2.FirstName = "Paul";

            string expected = "Paul";

            //--Act
            string actual = c1.FullName;

            //--Type
            //hence this tests passes and c1 is also Paul
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void StaticTest()
        {
            //--Arrange
            //if we access c1 we cant see any statis 
            var c1 = new Customer();
            c1.FirstName = "Colin";
            Customer.InstanceCount += 1; //must access it from the class

            var c2 = new Customer();
            c2.FirstName = "Logan";
            Customer.InstanceCount += 1;

            var c3 = new Customer();
            c3.FirstName = "Mason";
            Customer.InstanceCount += 1;

            //--Act

            //--Assert
            Assert.AreEqual(3, Customer.InstanceCount);
        
        }
    }
}
