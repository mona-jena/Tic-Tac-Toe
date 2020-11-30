using System;
using System.Threading;
using TicTacToe;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            while (true)
            {
                Console.WriteLine("What size board would you like to play with? ");
                var boardSize = Console.ReadLine();
                bool validSize = int.TryParse(boardSize, out var size);

                if (!validSize)
                {
                    continue;
                }
                
                Board board = new Board(size);
                
                Console.WriteLine("Player 1, what symbol would you like to be?");
                char player1Symbol = Console.ReadLine();
                var player1 = new Player(player1Symbol, new ReaderWriter());
                Console.WriteLine("Player 2, what symbol would you like to be?");
                var player2Symbol = Console.ReadLine();
                var player2 = new Player(playerwSymbol, new ReaderWriter());
                Game game = new Game(player1, player2, size);
                
            }
        }
    }
}