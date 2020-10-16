using System;
using System.Net.WebSockets;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {

        [Fact]
        public void BookValidateGrade()
        {
            var book = new Book("Book 1");
            book.AddGrade(105);
            var result = book.GetStatistics();

            Assert.Equal(0, result.Average);
            Assert.Equal(0, result.High);
            Assert.Equal(0, result.Low);

        }

        [Fact]
        public void BookCalculatesAnAverageGrade()
        {

            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var Result =  book.GetStatistics();

            // assert
            Assert.Equal(85.6, Result.Average, 1);
            Assert.Equal(90.5, Result.High, 1);
            Assert.Equal(77.3, Result.Low, 1);
        }
    }
}
