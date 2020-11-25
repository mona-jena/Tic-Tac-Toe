using System;

namespace TicTacToe
{
    public class Board
    {
        private readonly char[][] _board = new char[3][];

        public int Size { get;}

        public Board(int size)
        {
            Size = size;
            for (var i = 0; i < size; i++)
            {
                _board[i] = new char[] {'.', '.', '.'};
            }
        }

        public void UpdateSquare(Coordinate coord, char symbol)
        {
            _board[coord.X][coord.Y] = symbol;
        }
        
        public char GetSquare(Coordinate coord)
        {
            return _board[coord.X][coord.Y];
        }
        
        public string PrintBoard()
        {
            //need to implement 
            return _board.ToString();
        }
    }
}