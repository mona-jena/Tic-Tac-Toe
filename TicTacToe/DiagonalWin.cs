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
            /*Coordinate firstCoord = new Coordinate() {X = 0, Y = 0};
            var value = board.GetSquare(firstCoord);
            if (value != '.')
            {
                symbol = value;
                if (CheckRightDiagonal(board, symbol) == true)
                {
                    return GameState.DiagonalWin;
                }
            }*/
            
            /*for (int x = 0; x < board.Size; x++)
            {
                for (int y = 0; y < board.Size; y++)
                {
                    Coordinate firstCoord = new Coordinate() {X = 0, Y = 0};
                    var value = board.GetSquare(firstCoord);
                    if (value != '.')
                    {
                        symbol = value;
                        if (CheckColumn(board, x, symbol) == true)
                        {
                            return GameState.VerticalWin;
                        };
                    }
                }
                
            }*/
            return GameState.InProgress;
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