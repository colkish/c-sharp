using ACM_BL; //must import from this namespace if I am going to reference it in this class
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BL.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //--Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            Customer expected = new Customer(1) //we can pass  in the Id to the class contructor but cant set it like below
            {
                 EmailAddress = "ckish@hublsoft.com"
                ,FirstName = "Colin"
                ,LastName = "Kish"
            };

            //--Act
            //Now instanciate my customer variable as what gets returned from customer repository retrieve
            Customer actual = customerRepository.Retreive(1);
            
            //--Assert
            //can't compare objects like this this will fail as these are different objects, even if they have the same properties
            //Assert.AreEqual(expected, actual); --this will fail the test
            //Need to compare like this:
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }
    }
}
