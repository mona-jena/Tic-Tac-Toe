namespace TicTacToe
{
    public class CoordinateValidator
    {
        public bool IsValid(Board board, Coordinate coord)
        {
            try
            {
                board.GetSquare(coord);
            }
            catch (System.IndexOutOfRangeException)
            {
                return false;
            }

            return true;
        }
    }
}