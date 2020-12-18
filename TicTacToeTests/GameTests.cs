using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        private readonly Game _game;
        private readonly Player _player1;
        private readonly TestReaderWriter _readerWriter1;
        private readonly TestReaderWriter _readerWriter2;

        public GameTests()
        {
            _readerWriter1 = new TestReaderWriter();
            _readerWriter2 = new TestReaderWriter();
            _player1 = new Player('X', _readerWriter1);
            var player2 = new Player('O', _readerWriter2);
            _game = new Game(_player1, player2, new Board(3), new TestReaderWriter());
        }

        [Fact]
        public void AcceptanceTestWhenPlayer1Wins()
        {
            _readerWriter1.AddMoves(new[] {"0,0", "1,0", "2,0"});
            _readerWriter2.AddMoves(new[] {"0,2", "1,2"});
            _game.PLay();
            Assert.Equal(GameState.HorizontalWin, _game.State);
            Assert.Equal(_player1, _game.CurrentPlayer);
        }

        [Fact]
        public void AcceptanceTestWhenPlayer2Wins()
        {
            _readerWriter1.AddMoves(new[] {"0,0", "1,1", "0,1"});
            _readerWriter2.AddMoves(new[] {"2,0", "2,2", "2,1"});
            var player1 = new Player('X', _readerWriter1);
            var player2 = new Player('O', _readerWriter2);
            var game = new Game(player1, player2, new Board(3), new TestReaderWriter());
            game.PLay();

            Assert.Equal(GameState.VerticalWin, game.State);
            Assert.Equal(player2, game.CurrentPlayer);
        }

        [Fact]
        public void AcceptanceTestWhenThereIsDraw()
        {
            _readerWriter1.AddMoves(new[] {"1,1", "1,0", "0,1", "2,2", "0,2"});
            _readerWriter2.AddMoves(new[] {"0,0", "2,0", "1,2", "2,1"});
            var player1 = new Player('X', _readerWriter1);
            var player2 = new Player('O', _readerWriter2);
            var game = new Game(player1, player2, new Board(3), new TestReaderWriter());
            game.PLay();

            Assert.Equal(GameState.Tie, game.State);
            Assert.Equal(player1, game.CurrentPlayer);
        }

        [Fact]
        public void TestIfPrintBoardOutputsInCorrectFormat()
        {
            _readerWriter1.AddMoves(new[] {"1,1", "1,0", "0,1", "2,2", "0,2"});
            _readerWriter2.AddMoves(new[] {"0,0", "2,0", "1,2", "2,1"});
            var player1 = new Player('X', _readerWriter1);
            var player2 = new Player('O', _readerWriter2);
            var game = new Game(player1, player2, new Board(3), new TestReaderWriter());

            var expectedBoard =
                ". . . \n" +
                ". . . \n" +
                ". . . \n";

            Assert.Equal(game.PrintBoard(), expectedBoard);
        }

        [Fact]
        public void TestIfPrintBoardOutputsInCorrectFormatWithSymbols()
        {
            _readerWriter1.AddMoves(new[] {"0,0", "1,0", "2,0"});
            _readerWriter2.AddMoves(new[] {"0,2", "1,2"});
            var player1 = new Player('X', _readerWriter1);
            var player2 = new Player('O', _readerWriter2);
            var game = new Game(player1, player2, new Board(3), new TestReaderWriter());
            game.PLay();

            var expectedBoard =
                "X X X \n" +
                ". . . \n" +
                "O O . \n";

            Assert.Equal(game.PrintBoard(), expectedBoard);
        }
        
        [Fact]
        public void SmartComputerShouldWinAgainstEasyComputer()
        {
            var spyReaderWriter = new TestReaderWriter();
            var board = new Board(3);
            
            var numberGenerator = new FakeNumberGenerator();
            numberGenerator.AddNumbers(new[] {0, 0, 2, 2, 2, 0, 0, 2});
            var aiPlayer = new EasyComputerPlayer(numberGenerator, 3, 'X');

            var smartComputerGenerator = new SmartComputerPlayer('O', 'X', board);
            var game = new Game(aiPlayer, smartComputerGenerator, board, spyReaderWriter);
            game.PLay();
            var expected = 
                "X O X \n" +
                ". O . \n" +
                ". O X \n";
            Assert.Equal(expected, game.PrintBoard());
        }

        [Fact]
        public void SmartComputerVsSmartComputerShouLdReturnDraw()
        {
            var board = new Board(3);
            var smartComputer1 = new SmartComputerPlayer('X', 'O', board);
            var smartComputer2 = new SmartComputerPlayer('O', 'X', board);
            var game = new Game(smartComputer1, smartComputer2, board, new TestReaderWriter());
            game.PLay();

            Assert.Equal(GameState.Tie, game.State);
        }
    }
}