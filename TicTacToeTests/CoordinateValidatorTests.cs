using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class CoordinateValidatorTests
    {
        [Fact]
        public void TakeTurnShouldAskUserToReEnterIfGivenOutOfBoundsCoordinate()
        {
            // do I need to use TestReaderWriter
            var board = new Board(3);

            var coordValidator = new CoordinateValidator();
            var coord = new Coordinate {X = 5, Y = 2};
            var isValid = coordValidator.IsValid(board, coord);

            Assert.False(isValid);
        }

        [Fact]
        public void TakeTurnShouldAskUserToReEnterCoordIfIndexTaken()
        {
            // do I need to use TestReaderWriter
            var board = new Board(3);
            var existingCoord = new Coordinate {X = 1, Y = 2};
            board.UpdateSquare(existingCoord, 'X');

            var coordValidator = new CoordinateValidator();
            var enteredCord = new Coordinate {X = 1, Y = 2};
            var isValid = coordValidator.IsValid(board, enteredCord);

            Assert.False(isValid);
        }
    }
}