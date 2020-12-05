namespace TicTacToe
{
    public interface IPlayer
    {
        char Symbol { get; }
        Coordinate TakeTurn();
    }
}