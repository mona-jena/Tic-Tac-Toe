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
            Board board = new Board(3);
            
            CoordinateValidator coordValidator = new CoordinateValidator();
            Coordinate coord = new Coordinate {X = 5, Y = 2};
            var isValid = coordValidator.IsValid(board, coord);
            
            Assert.False(isValid);
        }
        
        [Fact]
        public void TakeTurnShouldAskUserToReEnterCoordIfIndexTaken()
        {
            // do I need to use TestReaderWriter
            Board board = new Board(3);
            Coordinate existingCoord = new Coordinate {X = 1, Y = 2};
            board.UpdateSquare(existingCoord, 'X');
            
            CoordinateValidator coordValidator = new CoordinateValidator();
            Coordinate enteredCord = new Coordinate {X = 1, Y = 2};
            var isValid = coordValidator.IsValid(board, enteredCord);
            
            Assert.False(isValid);
        }
    }
}