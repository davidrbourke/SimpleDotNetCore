using System;
using Xunit;
using Simple.Models;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, 4);
        }

        [Fact]
        public void UserGetAgeInDays_DOB1980_DaysMatch()
        {
            // Arrange
            var user = new User
            {
                Firstname = "ABC",
                DOB = new DateTime(1980, 08, 31)
            };

            // Act
            var days = user.GetAgeInDays();

            // Assert
            Assert.True(days > 13000);
        }
    }
}
