using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Acme.Common;
using System.Collections.Generic;
using ACM_BL;

namespace Acme.CommonTest
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {

        // Arrange
        List<ILoggable> changeItems = new List<ILoggable>();

        Customer customer = new Customer(1)
        {
             EmailAddress = "colkish@hotmail.com"
            ,FirstName = "Colin"
            ,LastName = "Kish"
            ,AddressList = null
        };
        changeItems.Add(customer);

        var product = new Product(1)
        {
             ProductName = "Bike"
            ,ProductDescription = "A Nice Bike"
            ,CurentPrice = 1.21M

        };
        changeItems.Add(product);

        // Act
        LogginService.WriteToFile(changeItems);

        // Assert
        // nothing here to assert

        }
    }
}
