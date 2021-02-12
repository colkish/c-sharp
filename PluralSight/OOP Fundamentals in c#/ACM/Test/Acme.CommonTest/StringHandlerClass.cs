using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Acme.Common;

//REMEMBER TO ADD A REFERENCE TO THE ACME.COMMON NAMESPACE AND ABOVE!!!


namespace Acme.CommonTest
{
    [TestClass]
    public class StringHandlerClass
    {
        [TestMethod]
        public void InsertSpacesTest()
        {

            //--Arrange
            string source = "SonicScrewdriver";
            string expected = "Sonic Screwdriver";

            //-Act
            string actual = source.InsertSpaces();

            //--Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertSpacesTestWithExistingSpaces()
        {

            //--Arrange
            string source = "Sonic Screwdriver";
            string expected = "Sonic Screwdriver";

            //-Act
            string actual = source.InsertSpaces();

            //--Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
