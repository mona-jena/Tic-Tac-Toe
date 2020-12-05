namespace TicTacToe
{
    public class CoordinateValidator
    {
        public bool IsValid(Board board, Coordinate coord)
        {
            if (coord.X >= board.Size || coord.Y >= board.Size)
            {
                return false;
            } 
            else if (board.GetSquare(coord) != '.')
            {
                return false;
            }

            return true;
        }
    }
}