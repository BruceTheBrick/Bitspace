using Bitspace.Features;
using FluentAssertions;
using Xunit;

namespace Bitspace.Tests.Features.ConnectFour.Enumerators;

public class PieceEnumExtensionTests
{
    #region GetOtherPiece

    [Theory]
    [InlineData(Piece.One, Piece.Two)]
    [InlineData(Piece.Two, Piece.One)]
    private void FunctionName_Should(Piece initial, Piece expected)
    {
        //Arrange

        //Act
        var actual = initial.GetOpponent();

        //Assert
        actual.Should().Be(expected);
    }

    #endregion
        
    #region IsNotPlayerPiece

    [Theory]
    [InlineData(Piece.Empty)]
    [InlineData(Piece.Invalid)]
    public void IsNotPlayerPiece_ShouldReturnTrue_WhenPieceIsNotPlayerPiece(Piece piece)
    {
        // Arrange
            
        // Act
        var result = piece.IsNotPlayerPiece();

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(Piece.One)]
    [InlineData(Piece.Two)]
    public void IsNotPlayerPiece_ShouldReturnFalse_WhenPieceIsPlayerPiece(Piece piece)
    {
        // Arrange

        // Act
        var result = piece.IsNotPlayerPiece();

        // Assert
        result.Should().BeFalse();
    }
        
    #endregion

    #region IsPlayerPiece

    [Theory]
    [InlineData(Piece.One)]
    [InlineData(Piece.Two)]
    public void IsPlayerPiece_ShouldReturnTrue_WhenPieceIsPlayerPiece(Piece piece)
    {
        // Arrange
            
        // Act
        var result = piece.IsPlayerPiece();

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(Piece.Invalid)]
    [InlineData(Piece.Empty)]
    public void IsPlayerPiece_ShouldReturnFalse_WhenPieceIsNotPlayerPiece(Piece piece)
    {
        // Arrange

        // Act
        var result = piece.IsPlayerPiece();

        // Assert
        result.Should().BeFalse();
    }

    #endregion
}