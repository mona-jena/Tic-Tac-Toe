namespace TicTacToe
{
    internal class HorizontalWin : IWinCondition
    {
        public GameState HasWon(Board board)
        {
            return IterateThroughBoard(board);
        }

        private GameState IterateThroughBoard(Board board)
        {
            for (var y = 0; y < board.Size; y++)
            {
                var value = board.GetSquare(new Coordinate {X = 0, Y = y});

                if (value != '.' && CheckRow(board, y, value)) return GameState.HorizontalWin;
            }

            return GameState.InProgress;
        }

        private bool CheckRow(Board board, int y, char symbol)
        {
            for (var x = 1; x < board.Size; x++)
            {
                var coordValue = board.GetSquare(new Coordinate {X = x, Y = y});

                if (symbol != coordValue) return false;
            }

            return true;
        }
    }
}