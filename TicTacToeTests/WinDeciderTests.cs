using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class WinDeciderTests
    {
        [Fact]
        public void CheckIfGetGameStateReturnsHorizontalWin()
        {
            var board = new Board(3);
            Coordinate coord1 = new Coordinate() {X = 0, Y = 2};
            Coordinate coord2 = new Coordinate() {X = 1, Y = 2};
            Coordinate coord3 = new Coordinate() {X = 2, Y = 2};
            board.UpdateSquare(coord1, 'X');
            board.UpdateSquare(coord2, 'X');
            board.UpdateSquare(coord3, 'X');

            var winDecider = new WinDecider();
            var actual = winDecider.GetGameState(board);
            var expected = GameState.HorizontalWin;
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CheckIfGetGameStateReturnsVerticalWin()
        {
            var board = new Board(3);
            Coordinate coord1 = new Coordinate() {X = 1, Y = 0};
            Coordinate coord2 = new Coordinate() {X = 1, Y = 1};
            Coordinate coord3 = new Coordinate() {X = 1, Y = 2};
            board.UpdateSquare(coord1, 'X');
            board.UpdateSquare(coord2, 'X');
            board.UpdateSquare(coord3, 'X');

            var winDecider = new WinDecider();
            var actual = winDecider.GetGameState(board);
            var expected = GameState.VerticalWin;
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CheckIfGetGameStateReturnsRightDiagonalWin()
        {
            var board = new Board(3);
            Coordinate coord1 = new Coordinate() {X = 0, Y = 0};
            Coordinate coord2 = new Coordinate() {X = 1, Y = 1};
            Coordinate coord3 = new Coordinate() {X = 2, Y = 2};
            board.UpdateSquare(coord1, 'X');
            board.UpdateSquare(coord2, 'X');
            board.UpdateSquare(coord3, 'X');

            var winDecider = new WinDecider();
            var actual = winDecider.GetGameState(board);
            var expected = GameState.DiagonalWin;
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CheckIfGetGameStateReturnsLeftDiagonalWin()
        {
            var board = new Board(3);
            Coordinate coord1 = new Coordinate() {X = 2, Y = 0};
            Coordinate coord2 = new Coordinate() {X = 1, Y = 1};
            Coordinate coord3 = new Coordinate() {X = 0, Y = 2};
            board.UpdateSquare(coord1, 'X');
            board.UpdateSquare(coord2, 'X');
            board.UpdateSquare(coord3, 'X');

            var winDecider = new WinDecider();
            var actual = winDecider.GetGameState(board);
            var expected = GameState.DiagonalWin;
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CheckIfGetGameStateReturnsATie()
        {
            var board = new Board(3);
            board.UpdateSquare(new Coordinate  {X = 0, Y = 0}, 'O');
            board.UpdateSquare(new Coordinate  {X = 1, Y = 0}, 'X');
            board.UpdateSquare(new Coordinate  {X = 2, Y = 0}, 'X');
            board.UpdateSquare(new Coordinate  {X = 0, Y = 1}, 'X');
            board.UpdateSquare(new Coordinate  {X = 1, Y = 1}, 'X');
            board.UpdateSquare(new Coordinate  {X = 2, Y = 1}, 'O');
            board.UpdateSquare(new Coordinate  {X = 0, Y = 2}, 'O');
            board.UpdateSquare(new Coordinate  {X = 1, Y = 2}, 'O');
            board.UpdateSquare(new Coordinate  {X = 2, Y = 2}, 'X');
            
            var winDecider = new WinDecider();
            var actual = winDecider.GetGameState(board);
            var expected = GameState.Tie;
            
            Assert.Equal(expected, actual);
        }
    }
}