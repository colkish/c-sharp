using ACM_BL; //must import from this namespace if I am going to reference it in this class
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            Customer actual = customerRepository.Retrieve(1);
            
            //--Assert
            //can't compare objects like this this will fail as these are different objects, even if they have the same properties
            //Assert.AreEqual(expected, actual); --this will fail the test
            //Need to compare like this:
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }

        //as address repo is now part of the customer repo lets test it
        [TestMethod]   
        public void RetrieveExistingWithAddress()
        {
            //--Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            Customer expected = new Customer(1)
            {
                EmailAddress = "ckish@hublsoft.com",
                FirstName = "Colin",
                LastName = "Kish",
                //requires using System.Collections.Generic; at the top of the script
                AddressList = new List<Address>() //collection initialiser 
                    {
                        new Address()
                        {
                            AddressType = 1,
                            StreetLine1 = "14 Oughton Close",
                            StreetLine2 = "Leven Estate",
                            City = "Yarm",
                            StateProvince = "North Yorkshire",
                            PostalCode = "TS15 9SZ",
                            Country = "UK"
                        }
                        ,new Address()
                        {
                            AddressType = 2,
                            StreetLine1 = "72 Wetherall",
                            StreetLine2 = "Layfield Estate",
                            City = "Yarm",
                            StateProvince = "North Yorkshire",
                            PostalCode = "TS15 9TP",
                            Country = "UK"
                        }
                    }
            };


            //--Act
            Customer actual = customerRepository.Retrieve(1);

            //--Assert
            //can't compare customers that reference different customers objects even if they have the same property values, so must reference each value    
        
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);

            for (int i = 0; i < 1; i++)
            {
                Assert.AreEqual(expected.AddressList[i].AddressType, actual.AddressList[i].AddressType);
                Assert.AreEqual(expected.AddressList[i].StreetLine1, actual.AddressList[i].StreetLine1);
                Assert.AreEqual(expected.AddressList[i].StreetLine2, actual.AddressList[i].StreetLine2);
                Assert.AreEqual(expected.AddressList[i].City, actual.AddressList[i].City);
                Assert.AreEqual(expected.AddressList[i].StateProvince, actual.AddressList[i].StateProvince);
                Assert.AreEqual(expected.AddressList[i].PostalCode, actual.AddressList[i].PostalCode);
                Assert.AreEqual(expected.AddressList[i].Country, actual.AddressList[i].Country);

            }

        }
        
    }
}
