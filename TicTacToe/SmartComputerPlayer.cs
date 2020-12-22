namespace TicTacToe
{
    public class SmartComputerPlayer : IPlayer
    {
        private readonly Board _board;
        private readonly CoordinateValidator _coordinateValidator = new CoordinateValidator();
        private readonly char _humanPlayerSymbol;
        private readonly WinDecider _winDecider = new WinDecider();
        public char Symbol { get; }

        public SmartComputerPlayer(char symbol, char humanPlayerSymbol, Board realBoard)
        {
            Symbol = symbol;
            _humanPlayerSymbol = humanPlayerSymbol;
            _board = realBoard;
        }


        public Coordinate TakeTurn()
        {
            var computerMove = new Coordinate();
            for (var y = 0; y < _board.Size; y++)
            {
                for (var x = 0; x < _board.Size; x++)
                {
                    var possibleCoord = new Coordinate {X = x, Y = y};
                    var valid = _coordinateValidator.IsValid(_board, possibleCoord);
                    if (!valid)
                        continue;

                    computerMove = possibleCoord;
                    if (TryMove(possibleCoord))
                        return computerMove;
                }
            }

            var middleCord = new Coordinate {X = _board.Size / 2, Y = _board.Size / 2};
            if (_coordinateValidator.IsValid(_board, middleCord)) return middleCord;

            var topLeft = new Coordinate {X = 0, Y = 0};
            if (_coordinateValidator.IsValid(_board, topLeft)) return topLeft;

            var topRight = new Coordinate {X = _board.Size, Y = 0};
            if (_coordinateValidator.IsValid(_board, topRight)) return topRight;

            var bottomLeft = new Coordinate {X = 0, Y = _board.Size};
            if (_coordinateValidator.IsValid(_board, bottomLeft)) return bottomLeft;

            var bottomRight = new Coordinate {X = _board.Size, Y = _board.Size};
            if (_coordinateValidator.IsValid(_board, bottomRight)) return bottomRight;
            
            return computerMove;
        }


        private bool TryMove(Coordinate possibleCoord)
        {
            //var jsonBoard = JsonSerializer.Serialize(_board, new JsonSerializerOptions() {IgnoreReadOnlyProperties = false});
            //var boardCopy = JsonSerializer.Deserialize<Board>(jsonBoard);
            var humanBoardCopy = DeepCopy();
            humanBoardCopy.UpdateSquare(possibleCoord, _humanPlayerSymbol);
            var computerBoardCopy = DeepCopy();
            computerBoardCopy.UpdateSquare(possibleCoord, Symbol);

            if (_winDecider.GetGameState(computerBoardCopy) != GameState.InProgress)
                return true;

            if (_winDecider.GetGameState(humanBoardCopy) != GameState.InProgress)
                return true;

            return false;
        }

        private Board DeepCopy()
        {
            var boardCopy = new Board(_board.Size);
            for (var y = 0; y < _board.Size; y++)
            for (var x = 0; x < _board.Size; x++)
            {
                var coord = new Coordinate {X = x, Y = y};
                var value = _board.GetSquare(coord);
                boardCopy.UpdateSquare(coord, value);
            }

            return boardCopy;
        }
    }
}