namespace TicTacToe
{
    public class Board
    {
        private readonly char[][] _board;

        public Board(int size)
        {
            Size = size;
            _board = new char[size][];
            for (var i = 0; i < size; i++) _board[i] = new[] {'.', '.', '.'};
        }

        public int Size { get; }

        public void UpdateSquare(Coordinate coord, char symbol)
        {
            _board[coord.X][coord.Y] = symbol;
        }

        public char GetSquare(Coordinate coord)
        {
            return _board[coord.X][coord.Y];
        }
    }
}