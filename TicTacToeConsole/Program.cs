using System;
using TicTacToe;
using TicTacToeConsoleTests;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleReaderWriter = new ConsoleReaderWriter();
            consoleReaderWriter.Write("What size board would you like to play with? ");

            var boardSize = consoleReaderWriter.Read();
            var validBoardSize = CheckBoardSize(boardSize);
                
            // Console.WriteLine("How many players will be playing?");
            // var noOfPlayers = Console.ReadLine();
                
            consoleReaderWriter.Write("Player 1, what symbol would you like to be?");
            var player1Symbol = consoleReaderWriter.Read();
            var validSymbol1 = CheckSymbol(player1Symbol);
            var player1 = new Player(char.Parse(player1Symbol), consoleReaderWriter);
                
            consoleReaderWriter.Write("Player 2, what symbol would you like to be?");
            var player2Symbol = consoleReaderWriter.Read();
            var validSymbol2 = CheckSymbol(player2Symbol);
            var player2 = new Player(char.Parse(player2Symbol), consoleReaderWriter);
            
            
            
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