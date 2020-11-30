using System;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;
        private int _turnCount = 0;

        public Game(Player player1, Player player2, int size)
        {
            _board = new Board(size);
            _player1 = player1;
            _player2 = player2;
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
            while (true)
            {
                var userCoord = player.TakeTurn();
                var coordinateValidator = new CoordinateValidator();
                var valid = coordinateValidator.IsValid(_board, userCoord);
                if (!valid)
                {
                    continue;
                }
                _board.UpdateSquare(userCoord, player.Symbol);
                
                return GetState();
            }
        }


    }
}