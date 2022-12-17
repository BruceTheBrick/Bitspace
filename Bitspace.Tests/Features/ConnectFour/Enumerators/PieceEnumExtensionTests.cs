using Bitspace.Features;
using FluentAssertions;
using Xunit;

namespace Bitspace.Tests.Features.ConnectFour.Enumerators
{
    public class PieceEnumExtensionTests
    {
        #region GetOtherPiece

        [Theory]
        [InlineData(Piece.ONE, Piece.TWO)]
        [InlineData(Piece.TWO, Piece.ONE)]
        private void FunctionName_Should(Piece initial, Piece expected)
        {
            //Arrange

            //Act
            var actual = initial.GetOtherPiece();

            //Assert
            actual.Should().Be(expected);
        }

        #endregion
        
        #region IsNotPlayerPiece

        [Theory]
        [InlineData(Piece.EMPTY)]
        [InlineData(Piece.INVALID)]
        public void IsNotPlayerPiece_ShouldReturnTrue_WhenPieceIsNotPlayerPiece(Piece piece)
        {
            // Arrange
            
            // Act
            var result = piece.IsNotPlayerPiece();

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(Piece.ONE)]
        [InlineData(Piece.TWO)]
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
        [InlineData(Piece.ONE)]
        [InlineData(Piece.TWO)]
        public void IsPlayerPiece_ShouldReturnTrue_WhenPieceIsPlayerPiece(Piece piece)
        {
            // Arrange
            
            // Act
            var result = piece.IsPlayerPiece();

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(Piece.INVALID)]
        [InlineData(Piece.EMPTY)]
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
}