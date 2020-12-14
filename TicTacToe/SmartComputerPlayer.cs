using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public class SmartComputerPlayer : IPlayer
    {
        public char Symbol { get; }
        private readonly char _humanPlayerSymbol;
        private readonly Board _board;
        private readonly CoordinateValidator _coordinateValidator = new CoordinateValidator();
        private readonly WinDecider _winDecider = new WinDecider();

        public SmartComputerPlayer(char symbol, char humanPlayerSymbol, Board realBoard)
        {
            Symbol = symbol;
            _humanPlayerSymbol = humanPlayerSymbol;
            _board = realBoard;
        }

        public Coordinate TakeTurn()
        {
            var computerMove = new Coordinate();
            for (int y = 0; y < _board.Size; y++)
            {
                for (int x = 0; x < _board.Size; x++)
                {
                    var possibleCoord = new Coordinate {X = x, Y = y};
                    var valid = _coordinateValidator.IsValid(_board, possibleCoord);
                    if (!valid) continue;
                     
                    computerMove = possibleCoord; // is this helpful??
                    if (TryMove(possibleCoord))
                    {
                        return possibleCoord;
                    }
                }
            }

            return computerMove;
        }

        private bool TryMove(Coordinate possibleCoord)
        {
            var mockBoard = _board.DeepCopy();
            mockBoard.UpdateSquare(possibleCoord, _humanPlayerSymbol);
            return _winDecider.GetGameState(mockBoard) != GameState.InProgress;
        }
    }
}