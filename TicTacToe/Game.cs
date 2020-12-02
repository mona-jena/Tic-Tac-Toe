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
        private Coordinate _userCoord;
        
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
                var consoleReaderWriter = new ConsoleReaderWriter();
                consoleReaderWriter.Write("What size board would you like to play with? ");

                var boardSize = consoleReaderWriter.Read();
                var validBoardSize = CheckBoardSize(boardSize);
                
                // Console.WriteLine("How many players will be playing?");
                // var noOfPlayers = Console.ReadLine();
                
                consoleReaderWriter.Write("Player 1, what symbol would you like to be?");
                var player1Symbol = consoleReaderWriter.Read();
                var validSymbol1 = CheckIfValidSymbol(player1Symbol);
                var player1 = new Player(char.Parse(player1Symbol), consoleReaderWriter);
                
                consoleReaderWriter.Write("Player 2, what symbol would you like to be?");
                var player2Symbol = consoleReaderWriter.Read();
                var validSymbol2 = CheckIfValidSymbol(player2Symbol);
                var player2 = new Player(char.Parse(player2Symbol), consoleReaderWriter);
                
                var gameRoundResult = DoNextTurn();
                while (gameRoundResult == GameState.InProgress)
                {
                    gameRoundResult = DoNextTurn();
                }
            }
        }

        private bool CheckIfValidSymbol(string playerSymbol)
        {
            
            throw new NotImplementedException();
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
            
            var valid = false;
            while (!valid)
            { 
                _userCoord = _currentPlayer.TakeTurn();
                valid = _coordinateValidator.IsValid(_board, _userCoord);
            }
            _board.UpdateSquare(_userCoord, _currentPlayer.Symbol);
            return GetState();
        }


    }
}