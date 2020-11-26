namespace TicTacToe
{
    public class Draw : IWinCondition
    {
        public GameState HasWon(Board board)
        {
            return IterateBoard(board);
        }

        private GameState IterateBoard(Board board)
        {
            for (int y = 0; y < board.Size; y++)
            {
                for (int x = 0; x < board.Size; x++)
                {
                    if (board.GetSquare(new Coordinate() {X = x, Y = y}) != '.')
                    {
                        continue;
                    }

                    return GameState.InProgress;
                }
            }

            return GameState.Tie;
        }
    }
}