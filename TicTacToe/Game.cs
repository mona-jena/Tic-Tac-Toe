using System;
using TicTacToeConsoleTests;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;
        private Player _currentPlayer;
        private readonly CoordinateValidator _coordinateValidator = new CoordinateValidator();

        public Game(Player player1, Player player2, int size)
        {
            var validSize = CheckBoardSize(size);
            if (validSize)
            {
                _board = new Board(size);
            }
            
            _player1 = player1;
            _player2 = player2;
            _currentPlayer = _player1;
        }

        public void PLay()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            while (true)
            {
                var console = new ConsoleReaderWriter();
                console.Write("What size board would you like to play with? ");

                var boardSize = console.Read();
                var validBoardSize = CheckBoardSize(boardSize);
                
                // Console.WriteLine("How many players will be playing?");
                // var noOfPlayers = Console.ReadLine();
                
                console.Write("Player 1, what symbol would you like to be?");
                
                var player1Symbol = console.Read();
                
                var player1 = new Player(char.Parse(player1Symbol), console);
                console.Write("Player 2, what symbol would you like to be?");
                var player2Symbol = console.Read();
                var player2 = new Player(char.Parse(player2Symbol), console);
            }
        }

        public bool CheckBoardSize(string boardSize)
        {
            var validInteger = int.TryParse(boardSize, out var size);
            if (validInteger && size > 0)
            {
                return true;
            }

            return false;
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
            return _currentPlayer;
        }
        
        
        public GameState DoNextTurn()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
            
            Coordinate userCoord = null;
            var valid = false;
            while (!valid)
            { 
                userCoord = _currentPlayer.TakeTurn();
                valid = _coordinateValidator.IsValid(_board, userCoord);
            }
            _board.UpdateSquare(userCoord, _currentPlayer.Symbol);
            return GetState();
        }


    }
}