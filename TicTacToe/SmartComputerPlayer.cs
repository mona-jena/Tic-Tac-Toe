
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
                    if (!valid) continue;

                    computerMove = possibleCoord; // is this helpful??
                    if (TryMove(possibleCoord)) 
                        return possibleCoord;
                }
            }
            return computerMove;
        }

        private bool TryMove(Coordinate possibleCoord)
        {
            //var jsonBoard = JsonSerializer.Serialize(_board, new JsonSerializerOptions() {IgnoreReadOnlyProperties = false});
            //var boardCopy = JsonSerializer.Deserialize<Board>(jsonBoard);
            var boardCopy = DeepCopy();
            boardCopy.UpdateSquare(possibleCoord, _humanPlayerSymbol);
            return _winDecider.GetGameState(boardCopy) != GameState.InProgress;
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