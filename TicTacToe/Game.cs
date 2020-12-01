
using System;
using TicTacToeConsoleTests;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;
        private int _turnCount;

        public Game(Player player1, Player player2, int size)
        {
            _board = new Board(size);
            _player1 = player1;
            _player2 = player2;
        }

        public void PLay()
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
                
               
                // Console.WriteLine("How many players will be playing?");
                // var noOfPlayers = Console.ReadLine();
                
                Console.WriteLine("Player 1, what symbol would you like to be?");
                var player1Symbol = Console.ReadLine();
                
                var player1 = new Player(char.Parse(player1Symbol), new ConsoleReaderWriter(player1Symbol));
                Console.WriteLine("Player 2, what symbol would you like to be?");
                var player2Symbol = Console.ReadLine();
                var player2 = new Player(player2Symbol, new ConsoleReaderWriter());
                Game game = new Game(player1, player2, size);
                game.PrintBoard();

                //game.ValidateBoardSize();

            }
        }
        
        

        public GameState GetState()
        {
            var winDecider = new WinDecider();
            var gameState = winDecider.GetGameState(_board);
            return gameState;
        }


        public string PrintBoard()
        {
            var stringBoard = "";
            for (int y = 0; y < _board.Size; y++)
            {
                for (int x = 0; x < _board.Size; x++)
                {
                    var coord = new Coordinate { X = x, Y = y};
                    stringBoard += _board.GetSquare(coord) + " ";
                }

                stringBoard += "\n";
            }
            
            //CONDENSE

            return stringBoard;
        }
        

        public Player GetCurrentPlayer()
        {
            var currentPlayer = _turnCount % 2 == 1 ? _player1 : _player2;
            return currentPlayer;
        }
        
        
        public GameState DoNextTurn()
        {
            _turnCount++;
            var player = GetCurrentPlayer();
            var userCoord = new Coordinate();
            var valid = false;
            while (!valid)
            { 
                userCoord = player.TakeTurn();
                var coordinateValidator = new CoordinateValidator();
                valid = coordinateValidator.IsValid(_board, userCoord);
            }
            _board.UpdateSquare(userCoord, player.Symbol);
            return GetState();
        }


    }
}