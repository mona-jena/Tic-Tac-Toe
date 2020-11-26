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
            var value = board.GetSquare(new Coordinate() {X = 0, Y = 0});
            if (value != '.')
            {
                if (CheckRightDiagonal(board, value) || CheckLeftDiagonal(board, value))
                {
                    return GameState.DiagonalWin;
                }
            }
            
            return GameState.InProgress;
        }

        private bool CheckLeftDiagonal(Board board, char symbol)
        {
            for (int x = 1; x < board.Size; x--)
            {
                var y = x;
                Coordinate coord = new Coordinate() {X = x, Y = y};
                var value = board.GetSquare(coord);
                if (value != symbol)
                {
                    return false;
                }
            }

            return true;
        }


        private bool CheckRightDiagonal(Board board, char symbol)
        {
            for (int x = 1; x < board.Size; x++)
            {
                var y = x;
                Coordinate coord = new Coordinate() {X = x, Y = y};
                var value = board.GetSquare(coord);
                if (value != symbol)
                {
                    return false;
                }
                
            }

            return true;
        }
        
    }
}