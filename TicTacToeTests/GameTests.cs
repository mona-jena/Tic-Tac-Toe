using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    
    public class GameTests
    {
        private readonly Game _game;
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly TestReaderWriter _readerWriter1;
        private readonly TestReaderWriter _readerWriter2;


        public GameTests()
        {
            _readerWriter1 = new TestReaderWriter();
            _readerWriter2 = new TestReaderWriter();
            _player1 = new Player('X', _readerWriter1);
            _player2 = new Player('O', _readerWriter2);
            _game = new Game(_player1, _player2, 3, new TestReaderWriter());
        }
        
        [Fact]
        public void AcceptanceTestWhenPlayer1Wins()
        {
            _readerWriter1.AddMoves(new []{"0,0", "1,0", "2,0"});
            _readerWriter2.AddMoves(new []{"0,2", "1,2"});
            _game.PLay();
            Assert.Equal(GameState.HorizontalWin, _game.State);
            Assert.Equal(_player1, _game.GetCurrentPlayer());
        }
        
        [Fact]
        public void AcceptanceTestWhenPlayer2Wins()
        {
            _readerWriter1.AddMoves(new []{"0,0", "1,1", "0,1"});
            _readerWriter2.AddMoves(new []{"2,0", "2,2", "2,1"});
            var player1 = new Player('X', _readerWriter1);
            var player2 = new Player('O', _readerWriter2);
            Game game = new Game(player1, player2, 3, new TestReaderWriter());
            game.PLay();

            Assert.Equal(GameState.VerticalWin, game.State);
            Assert.Equal(player2, game.GetCurrentPlayer());
        }
        
        // draw test
        [Fact]
        public void AcceptanceTestWhenThereIsDraw()
        {
            _readerWriter1.AddMoves(new []{"1,1", "1,0", "0,1", "2,2", "0,2"});
            _readerWriter2.AddMoves(new []{"0,0", "2,0", "1,2", "2,1"});
            var player1 = new Player('X', _readerWriter1);
            var player2 = new Player('O', _readerWriter2);
            Game game = new Game(player1, player2, 3, new TestReaderWriter());
            game.PLay();

            Assert.Equal(GameState.Tie, game.State);
            Assert.Equal(player1, game.GetCurrentPlayer());
        }

        [Fact]
        public void TestIfPrintBoardOutputsInCorrectFormat()
        {
            _readerWriter1.AddMoves(new []{"1,1", "1,0", "0,1", "2,2", "0,2"});
            _readerWriter2.AddMoves(new []{"0,0", "2,0", "1,2", "2,1"});
            var player1 = new Player('X', _readerWriter1);
            var player2 = new Player('O', _readerWriter2);
            Game game = new Game(player1, player2, 3, new TestReaderWriter());
          
            var expectedBoard =
                ". . . \n" +
                ". . . \n" +
                ". . . \n";

            Assert.Equal(game.PrintBoard(), expectedBoard);
        }
        
        [Fact]
        public void TestIfPrintBoardOutputsInCorrectFormatWithSymbols()
        {
            _readerWriter1.AddMoves(new []{"0,0", "1,0", "2,0"});
            _readerWriter2.AddMoves(new []{"0,2", "1,2"});
            var player1 = new Player('X', _readerWriter1);
            var player2 = new Player('O', _readerWriter2);
            Game game = new Game(player1, player2, 3, new TestReaderWriter());
            game.PLay();
            
            var expectedBoard =
                "X X X \n" +
                ". . . \n" +
                "O O . \n";

            Assert.Equal(game.PrintBoard(), expectedBoard);
        }
        
      
    }
}

//Repeat code in each test --> put in helper class?