namespace Bitspace.Tests.Extensions;

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
        formattedString.Should().Be($"{dateTime:dddd}, {dateTime.Day} {dateTime:MMM}");
    }
        
    #endregion
}