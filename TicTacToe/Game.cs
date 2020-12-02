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
                
                
                var gameRoundResult = DoNextTurn();
                while (gameRoundResult == GameState.InProgress)
                {
                    gameRoundResult = DoNextTurn();
                }
            }
        }
        
        // do while loops for each validation inside Play() while loop
        // separate each validation into 2 methods --> one that checks if valid, other to prompt user to try again --> would it be better in Play() or sep method?
        // make BoardValidator class to check above 

        private bool CheckSymbol(string playerSymbol)
        {
            // prompt user to try again - while loop until correct symbol 
            if (playerSymbol.Length == 1)
            {
                char.Parse(playerSymbol);
            }
            throw new NotImplementedException();
        }

        public bool CheckBoardSize(string boardSize)
        {
            // prompt user to try again - while loop until correct symbol
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