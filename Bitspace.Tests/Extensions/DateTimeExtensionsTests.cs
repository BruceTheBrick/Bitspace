using System;
using Bitspace.Extensions;
using FluentAssertions;
using Xunit;

namespace Bitspace.Tests.Extensions
{
    public class DateTimeExtensionsTests
    {
        #region ToDisplyString
        
        [Fact]
        public void ToDisplayString_ShouldFormatDateTime()
        {
            //Arrange
            var dateTime = DateTime.Now;
            
            //Act
            var formattedString = dateTime.ToDisplayString();

            //Assert
            formattedString.Should().Be($"{dateTime.ToString("dddd")}, {dateTime.Day} {dateTime.ToString("MMM")}");
        }
        
        #endregion
    }
}