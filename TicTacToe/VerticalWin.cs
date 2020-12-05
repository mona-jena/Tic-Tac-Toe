namespace TicTacToe
{
    internal class VerticalWin : IWinCondition
    {
        public GameState HasWon(Board board)
        {
            return IterateBoard(board);
        }

        private GameState IterateBoard(Board board)
        {
            for (var x = 0; x < board.Size; x++)
            {
                var value = board.GetSquare(new Coordinate {X = x, Y = 0});

                if (value != '.' && CheckColumn(board, x, value)) return GameState.VerticalWin;
            }

            return GameState.InProgress;
        }

        private bool CheckColumn(Board board, int x, char symbol)
        {
            for (var y = 1; y < board.Size; y++)
            {
                var coordValue = board.GetSquare(new Coordinate {X = x, Y = y});

                if (symbol != coordValue) return false;
            }

            return true;
        }
    }
}