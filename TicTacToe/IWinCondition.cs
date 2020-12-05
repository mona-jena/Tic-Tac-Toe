namespace TicTacToe
{
    public interface IWinCondition
    {
        GameState HasWon(Board board);
    }
}