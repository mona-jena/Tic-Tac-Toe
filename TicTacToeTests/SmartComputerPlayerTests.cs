using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class SmartComputerPlayerTests
    {
        [Fact]
        public void SymbolShouldReturnANonNullChar()
        {
            var aiPlayer = new SmartComputerPlayer('O', 'X', new Board(3));
            var aiSymbol = aiPlayer.Symbol;
            var expectedSymbol = 'O';

            Assert.Equal(expectedSymbol, aiSymbol);
        }

        [Fact]
        public void BlockPossibleHorizontalWin()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate(1, 1), 'X');
            board.UpdateSquare(new Coordinate(2, 1), 'X');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);

            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCoord = new Coordinate {X = 0, Y = 1};

            Assert.Equal(expectedCoord, smartPlayerTurn);
        }

        [Fact]
        public void BlockPossibleVerticalWin()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate(1, 0), 'X');
            board.UpdateSquare(new Coordinate(1, 1), 'X');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);

            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCoord = new Coordinate {X = 1, Y = 2};

            Assert.Equal(expectedCoord, smartPlayerTurn);
        }

        [Fact]
        public void BlockPossibleLeftDiagonalWin()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate(2, 0), 'X');
            board.UpdateSquare(new Coordinate(1, 1), 'X');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);

            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCoord = new Coordinate {X = 0, Y = 2};

            Assert.Equal(expectedCoord, smartPlayerTurn);
        }

        [Fact]
        public void BlockPossibleRightDiagonalWin()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate(0, 0), 'X');
            board.UpdateSquare(new Coordinate(2, 2), 'X');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);

            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCoord = new Coordinate {X = 1, Y = 1};

            Assert.Equal(expectedCoord, smartPlayerTurn);
        }

        [Fact]
        public void MakeADraw()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate(0, 0), 'X');
            board.UpdateSquare(new Coordinate(2, 0), 'X');
            board.UpdateSquare(new Coordinate(1, 1), 'X');
            board.UpdateSquare(new Coordinate(2, 1), 'X');
            board.UpdateSquare(new Coordinate(1, 0), 'O');
            board.UpdateSquare(new Coordinate(0, 1), 'O');
            board.UpdateSquare(new Coordinate(2, 2), 'O');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);

            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCoord = new Coordinate {X = 0, Y = 2};

            Assert.Equal(expectedCoord, smartPlayerTurn);
        }

        [Fact]
        public void MakeMoveWhenFirstPlayer()
        {
            var board = new Board(3);
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);
            
            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCord = new Coordinate() {X = 1, Y = 1};
           
            Assert.Equal(expectedCord, smartPlayerTurn);
        }

        [Fact]
        public void SecondMoveReturnsFirstCornerOfGridIfMiddleCoordinateIsTaken()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate (1, 1), 'X');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);
            
            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCord = new Coordinate() {X = 2, Y = 2};
           
            Assert.Equal(expectedCord, smartPlayerTurn);
        }

        [Fact]
        public void SecondMoveReturnsMiddleCoordinateIfCornerCoordinateIsTaken()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate (0, 0), 'X');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);
            
            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCord = new Coordinate() {X = 1, Y = 1};
           
            Assert.Equal(expectedCord, smartPlayerTurn);
        }
        
        
        [Fact]
        public void ComputerHorizontalWin()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate(1, 1), 'X');
            board.UpdateSquare(new Coordinate(2, 1), 'X');
            board.UpdateSquare(new Coordinate(0, 0), 'O');
            board.UpdateSquare(new Coordinate(1, 0), 'O');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);

            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCoord = new Coordinate {X = 2, Y = 1};

            Assert.Equal(expectedCoord, smartPlayerTurn);
        }

        [Fact]
        public void ComputerVerticalWin()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate(0, 0), 'X');
            board.UpdateSquare(new Coordinate(0, 1), 'X');
            board.UpdateSquare(new Coordinate(2, 0), 'X');
            board.UpdateSquare(new Coordinate(2, 2), 'X');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);

            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCoord = new Coordinate {X = 2, Y = 1};

            Assert.Equal(expectedCoord, smartPlayerTurn);
        }

        
        //if there any point testing these two?
        
        [Fact]
        public void ComputerLeftDiagonalWin()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate(2, 1), 'X');
            board.UpdateSquare(new Coordinate(2, 2), 'X');
            board.UpdateSquare(new Coordinate(2, 0), 'O');
            board.UpdateSquare(new Coordinate(1, 1), 'O');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);

            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCoord = new Coordinate {X = 0, Y = 2};

            Assert.Equal(expectedCoord, smartPlayerTurn);
        }

        [Fact]
        public void ComputerRightDiagonalWin()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate(2, 0), 'X');
            board.UpdateSquare(new Coordinate(1, 0), 'X');
            board.UpdateSquare(new Coordinate(2, 2), 'O');
            board.UpdateSquare(new Coordinate(1, 1), 'O');
            var smartComputerPlayer = new SmartComputerPlayer('O', 'X', board);

            var smartPlayerTurn = smartComputerPlayer.TakeTurn();
            var expectedCoord = new Coordinate {X = 0, Y = 0};

            Assert.Equal(expectedCoord, smartPlayerTurn);
        }
    }
}