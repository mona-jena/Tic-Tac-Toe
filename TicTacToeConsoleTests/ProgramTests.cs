using System;
using TicTacToe;
using Xunit;

namespace TicTacToeConsoleTests
{
    public class ProgramTests
    {
        [Fact]
        public void AcceptanceTestWhenPlayer1Wins()
        {
            var readerWriter1 = new ConsoleReaderWriter(new []{"0,0", "1,0", "2,0"});
            var readerWriter2 = new ConsoleReaderWriter(new []{"0,2", "1,2"});
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
    }

    
}