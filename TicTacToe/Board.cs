namespace TicTacToe
{
    public class Board
    {
        public readonly char[][] _board;
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
        
        
    }
}