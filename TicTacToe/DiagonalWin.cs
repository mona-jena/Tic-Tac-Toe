namespace TicTacToe
{
    public class DiagonalWin : IWinCondition
    {
        public GameState HasWon(Board board)
        {
            return IterateBoard(board);
        }
        
        private GameState IterateBoard(Board board)
        {
            var topLeftCoord = board.GetSquare(new Coordinate() {X = 0, Y = 0});
            if (topLeftCoord != '.')
            {
                if (CheckRightDiagonal(board, topLeftCoord))
                {
                    return GameState.DiagonalWin;
                }
            }
            
            var topRightCoord = board.GetSquare(new Coordinate() {X = board.Size - 1, Y = 0});
            if (topRightCoord != '.')
            {
                if (CheckLeftDiagonal(board, topRightCoord))
                {
                    return GameState.DiagonalWin;
                }
            }
            
            return GameState.InProgress;
        }

        private bool CheckLeftDiagonal(Board board, char symbol)
        {
            var y = 1;
            for (int x = board.Size - 2; x >= 0; x--)
            {
                var value = board.GetSquare(new Coordinate() {X = x, Y = y});
                if (value != symbol)
                {
                    return false;
                }
                y++;
            }
            return true;
        }


        private bool CheckRightDiagonal(Board board, char symbol)
        {
            for (int x = 1; x < board.Size; x++)
            {
                var y = x;
                var value = board.GetSquare(new Coordinate() {X = x, Y = y});
                if (value != symbol)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}