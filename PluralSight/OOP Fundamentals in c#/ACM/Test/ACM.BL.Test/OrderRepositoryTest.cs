using ACM_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BL.Test
{
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void OrderRepositoryValid()
        {
        //--Arrange
        //new instance of Order repo which is what we want to test
        OrderRepository orderRepository = new OrderRepository();
        Order expected = new Order(1)
        {
            OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0))
        };

        //--Act
        Order actual = orderRepository.Retrieve(1);

        //--assert
         Assert.AreEqual(actual.OrderDate,expected.OrderDate);
        }
    }
}
