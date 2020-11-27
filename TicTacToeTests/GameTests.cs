using System;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void AcceptanceTest()
        {
            var readerWriter1 = new TestReaderWriter(new string[]{"1,1", "1,2", "1,3"});
            var readerWriter2 = new TestReaderWriter(new string[]{"2,0", "2,1"});
            var player1 = new Player('X', readerWriter1);
            var player2 = new Player('O', readerWriter2);
            var size = 3;
            Game game = new Game(player1, player2, size);
            while (game.GetState() == GameState.InProgress)
            {
                game.DoNextTurn();
            }

            Assert.Equal(GameState.HorizontalWin, game.GetState());
            Assert.Equal(player1, game.GetCurrentPlayer());
        }
        
        //player 2 test
        
        // draw test
    }
}