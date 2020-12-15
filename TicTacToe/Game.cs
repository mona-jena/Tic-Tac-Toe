using System;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board _board;
        private readonly CoordinateValidator _coordinateValidator = new CoordinateValidator();
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly IReaderWriter _readerWriter;
        private Coordinate _userCoord;


        public Game(IPlayer player1, IPlayer player2, int size, IReaderWriter readerWriter)
        {
            if (size < 3) throw new ArgumentException("Size must be greater than 3");
            _board = new Board(size);

            _player1 = player1;
            _player2 = player2;
            CurrentPlayer = _player1;
            _readerWriter = readerWriter ?? throw new ArgumentException(nameof(readerWriter));
        }

        public IPlayer CurrentPlayer { get; private set; }
        public GameState State { get; private set; }


        public void PLay()
        {
            while (State == GameState.InProgress) DoNextTurn();
        }


        private void ChangeState()
        {
            var winDecider = new WinDecider();
            State = winDecider.GetGameState(_board);
            if (State == GameState.InProgress) CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
        }


        public string PrintBoard()
        {
            var stringBoard = "";
            for (var y = 0; y < _board.Size; y++)
            {
                for (var x = 0; x < _board.Size; x++)
                {
                    var coord = new Coordinate {X = x, Y = y};
                    stringBoard += _board.GetSquare(coord) + " ";
                }

                stringBoard += "\n";
            }

            return stringBoard;
        }


        private void DoNextTurn()
        {
            var valid = false;
            while (!valid)
            {
                _userCoord = CurrentPlayer.TakeTurn();
                valid = _coordinateValidator.IsValid(_board, _userCoord);
                if (valid == false)
                    _readerWriter.Write("Please enter valid coordinate (x,y)\n");
            }

            _board.UpdateSquare(_userCoord, CurrentPlayer.Symbol);
            ChangeState();
        }
    }
}