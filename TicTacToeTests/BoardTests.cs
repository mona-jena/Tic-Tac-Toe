using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BoardTests
    {
        [Fact]
        public void GetSquareShouldReturnSquare()
        {
            Coordinate coord = new Coordinate()
            {
                X = 0,
                Y = 0
            };
            
            var board = new Board(3);
            var result = board.GetSquare(coord);

            var expected = '.';
            Assert.Equal(expected, result);

        }
        
        
        [Fact]
        public void UpdateSquareShouldChangeValuesAtASpecifiedSquare()
        {
            Coordinate coord = new Coordinate()
            {
                X = 0,
                Y = 0
            };
            
            var board = new Board(3);
            board.UpdateSquare(coord, 'X');
            var result = board.GetSquare(coord);
            var expected = 'X';
            Assert.Equal(expected, result);
        }

        [Fact]
        public void UpdateSquareShouldChangeValuesAtASpecifiedSquareFor5X5()
        {
            Coordinate coord = new Coordinate()
            {
                X = 0,
                Y = 0
            };
            
            var board = new Board(5);
            board.UpdateSquare(coord, 'X');
            var result = board.GetSquare(coord);
            var expected = 'X';
            Assert.Equal(expected, result);
        }
    }
}