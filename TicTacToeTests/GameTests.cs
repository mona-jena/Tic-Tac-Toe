using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void AcceptanceTestWhenPlayer1Wins()
        {
            var readerWriter1 = new TestReaderWriter(new []{"0,0", "1,0", "2,0"});
            var readerWriter2 = new TestReaderWriter(new []{"0,2", "1,2"});
            var player1 = new Player('X', readerWriter1);
            var player2 = new Player('O', readerWriter2);
            Game game = new Game(player1, player2, 3);
            game.DoNextTurn();
            while (game.GetState() == GameState.InProgress)
            {
                game.DoNextTurn();
            }

            Assert.Equal(GameState.HorizontalWin, game.GetState());
            Assert.Equal(player1, game.GetCurrentPlayer());
        }
        
        //player 2 test
        [Fact]
        public void AcceptanceTestWhenPlayer2Wins()
        {
            var readerWriter1 = new TestReaderWriter(new []{"0,0", "1,1", "0,1"});
            var readerWriter2 = new TestReaderWriter(new []{"2,0", "2,2", "2,1"});
            var player1 = new Player('X', readerWriter1);
            var player2 = new Player('O', readerWriter2);
            Game game = new Game(player1, player2, 3);
            game.DoNextTurn();
            while (game.GetState() == GameState.InProgress)
            {
                game.DoNextTurn();
            }

            Assert.Equal(GameState.VerticalWin, game.GetState());
            Assert.Equal(player2, game.GetCurrentPlayer());
        }
        
        // draw test
        [Fact]
        public void AcceptanceTestWhenThereIsDraw()
        {
            var readerWriter1 = new TestReaderWriter(new []{"1,1", "1,0", "0,1", "2,2", "0,2"});
            var readerWriter2 = new TestReaderWriter(new []{"0,0", "2,0", "1,2", "2,1"});
            var player1 = new Player('X', readerWriter1);
            var player2 = new Player('O', readerWriter2);
            Game game = new Game(player1, player2, 3);
            game.DoNextTurn();
            while (game.GetState() == GameState.InProgress)
            {
                game.DoNextTurn();
            }

            Assert.Equal(GameState.Tie, game.GetState());
            Assert.Equal(player1, game.GetCurrentPlayer());
        }

        [Fact]
        public void TestIfPrintBoardOutputsInCorrectFormat()
        {
            var readerWriter1 = new TestReaderWriter(new []{"1,1", "1,0", "0,1", "2,2", "0,2"});
            var readerWriter2 = new TestReaderWriter(new []{"0,0", "2,0", "1,2", "2,1"});
            var player1 = new Player('X', readerWriter1);
            var player2 = new Player('O', readerWriter2);
            Game game = new Game(player1, player2, 3);
            //game.DoNextTurn();
            /*while (game.GetState() == GameState.InProgress)
            {
                game.DoNextTurn();
            }*/
            var expectedBoard =
                ". . . \n" +
                ". . . \n" +
                ". . . \n";

            Assert.Equal(game.PrintBoard(), expectedBoard);
        }
        
        [Fact]
        public void TestIfPrintBoardOutputsInCorrectFormatWithSymbols()
        {
            var readerWriter1 = new TestReaderWriter(new []{"0,0", "1,0", "2,0"});
            var readerWriter2 = new TestReaderWriter(new []{"0,2", "1,2"});
            var player1 = new Player('X', readerWriter1);
            var player2 = new Player('O', readerWriter2);
            Game game = new Game(player1, player2, 3);
            game.DoNextTurn();
            while (game.GetState() == GameState.InProgress)
            {
                game.DoNextTurn();
            }
            var expectedBoard =
                "X X X \n" +
                ". . . \n" +
                "O O . \n";

            Assert.Equal(game.PrintBoard(), expectedBoard);
        }
        
    }
}