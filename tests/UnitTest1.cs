using System;
using Xunit;
using Museet.Models;

namespace tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            //var room1 = new Room("Test");
            //var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");

            // Act

            // Assert
            var x = 2;
            var y = 3;
            // var expected = int.Parse(Console.ReadLine());
            var expected = 10;
            var actual = x * y;


            Assert.Equal(expected, actual);
        }
    }
}
