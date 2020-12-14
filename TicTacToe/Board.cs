using System;

namespace TicTacToe
{
    public class Board
    {
        private readonly char[][] _board;
        public int Size { get; }

        public Board(int size)
        {
            Size = size;
            _board = new char[Size][];
            for (var i = 0; i < Size; i++) _board[i] = new[] {'.', '.', '.'};
        }

        public void UpdateSquare(Coordinate coord, char symbol)
        {
            _board[coord.X][coord.Y] = symbol;
        }

        public char GetSquare(Coordinate coord)
        {
            return _board[coord.X][coord.Y];
        }

        public Board DeepCopy()
        {
            var boardMock = new Board(Size);
            
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    var coord = new Coordinate {X = x, Y = y};
                    var value = GetSquare(coord);
                    boardMock.UpdateSquare(coord, value);
                }
            }
            return boardMock;
        }
        
    }
}