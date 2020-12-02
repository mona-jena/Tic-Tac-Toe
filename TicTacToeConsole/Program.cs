using System;
using TicTacToe;
using TicTacToeConsoleTests;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //what size
            game.ValidateBoardSize();
            //what symbol
            var player1 = new Player();
            //what symbol 
            var player2 = new Player();
            Game game = new Game(player1, player2, size);
            game.PLay();
            //declare winner
        }
    }
}