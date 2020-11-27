using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class CoordinateValidatorTests
    {
        [Fact]
        public void TakeTurnShouldPromptUserAboutOutOfBoundsCoordinate()
        {
            // do I need to use TestReaderWriter
            Board board = new Board(3);
            CoordinateValidator coordValidator = new CoordinateValidator();
            Coordinate coord = new Coordinate {X = 5, Y = 4};
            
            var isValid = coordValidator.IsValid(board, coord);
            var expected = false;
            
            Assert.Equal(expected, isValid);
        }
    }
}