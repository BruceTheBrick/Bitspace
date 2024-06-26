﻿namespace Bitspace.Tests.Services;

public class TimeoutServiceTests : UnitTestBase<TimeoutService>
{
    #region IsExpired

    [Fact]
    public void IsExpired_ShouldReturnFalse_WhenExpiryMinutesIsNull()
    {
        // Arrange
        
        // Act
        var isExpired = Sut.IsExpired();

        // Assert
        isExpired.Should().BeFalse();
    }

    [Fact]
    public void IsExpired_ShouldReturnTrue_WhenDateTimeLastUpdateIsNull()
    {
        // Arrange
        Sut.ExpiryMinutes = 5;

        // Act
        var isExpired = Sut.IsExpired();

        // Assert
        isExpired.Should().BeTrue();
    }
    
    [Fact]
    public void IsExpired_ShouldReturnTrue_WhenTimeElapsedIsOverThreshold()
    {
        //Arrange
        Sut.ExpiryMinutes = 5;
        Sut.DateTimeLastUpdate = DateTime.Now - TimeSpan.FromMinutes(10);

        //Act
        var isExpired = Sut.IsExpired();

        //Assert
        isExpired.Should().BeTrue();
    }

    [Fact]
    public void IsExpired_ShouldReturnFalse_WhenTimeElapsedIsLessThanThreshold()
    {
        //Arrange
        Sut.ExpiryMinutes = 5;
        Sut.DateTimeLastUpdate = DateTime.Now - TimeSpan.FromMinutes(1);

        //Act
        var isExpired = Sut.IsExpired();

        //Assert
        isExpired.Should().BeFalse();
    }

    [Fact]
    public void IsExpiredOverload_ShouldReturnTrue_WhenTimeElapsedIsOverThreshold()
    {
        //Arrange
        var expiryMins = 5;
        var dateTimeLastUpdated = DateTime.Now - TimeSpan.FromMinutes(10);

        //Act
        var isExpired = Sut.IsExpired(dateTimeLastUpdated, expiryMins);

        //Assert
        isExpired.Should().BeTrue();
    }

    [Fact]
    public void IsExpiredOverload_ShouldReturnFalse_WhenTimeElapsedIsLessThanThreshold()
    {
        //Arrange
        var expiryMins = 5;
        var dateTimeLastUpdated = DateTime.Now - TimeSpan.FromMinutes(1);

        //Act
        var isExpired = Sut.IsExpired(dateTimeLastUpdated, expiryMins);

        //Assert
        isExpired.Should().BeFalse();
    }

    [Fact]
    public void IsExpiredOverload_ShouldReturnTrue_WhenDateTimeLastUpdateIsNull()
    {
        // Arrange
        var expiryMins = 5;
        var dateTimeLastUpdated = DateTime.MinValue;

        // Act
        var isExpired = Sut.IsExpired(dateTimeLastUpdated, expiryMins);

        // Assert
        isExpired.Should().BeTrue();
    }

    [Fact]
    private void IsExpiredOverload_ShouldReturnFalse_WhenExpiryMinutesIsNull()
    {
        //Arrange
        Sut.ExpiryMinutes = null;

        //Act
        var result = Sut.IsExpired(DateTime.Now);

        //Assert
        result.Should().BeFalse();
    }

    [Fact]
    private void IsExpiredOverload_ShouldReturnTrue_WhenDateTimeLastUpdateIsMinDate()
    {
        //Arrange
        Sut.ExpiryMinutes = 1;

        //Act
        var result = Sut.IsExpired(DateTime.MinValue);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    private void IsExpiredOverload_ShouldReturnFalse_WhenElapsedTimeIsLessThanExpiryThreshold()
    {
        //Arrange
        Sut.ExpiryMinutes = 10;

        //Act
        var result = Sut.IsExpired(DateTime.Now.AddMinutes(-5));

        //Assert
        result.Should().BeFalse();
    }
        
    [Fact]
    private void IsExpiredOverload_ShouldReturnTrue_WhenElapsedTimeIsGreaterThanExpiryThreshold()
    {
        //Arrange
        Sut.ExpiryMinutes = 10;

        //Act
        var result = Sut.IsExpired(DateTime.Now.AddMinutes(-15));

        //Assert
        result.Should().BeTrue();
    }

    #endregion

    #region Update

    [Fact]
    public void Update_ShouldSetDateTimeLastUpdate()
    {
        //Arrange
        var oldDateTime = DateTime.Now - TimeSpan.FromMinutes(5);
        Sut.DateTimeLastUpdate = oldDateTime;

        //Act
        Sut.Update();

        //Assert
        Sut.DateTimeLastUpdate.Should().BeOnOrAfter(oldDateTime);
    }

    #endregion
}