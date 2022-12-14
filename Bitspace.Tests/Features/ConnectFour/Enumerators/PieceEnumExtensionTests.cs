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
    }
}