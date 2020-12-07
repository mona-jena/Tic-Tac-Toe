namespace TicTacToe
{
    public class EasyComputerPlayer : IPlayer
    {
        private readonly INumberGenerator _number;
        private readonly int _boardSize;
        public char Symbol { get; } = 'X';

        public EasyComputerPlayer(INumberGenerator number, int boardSize)
        {
            _number = number;
            _boardSize = boardSize;
        }
            
        public Coordinate TakeTurn()
        {
            var randomX = _number.Next(_boardSize);
            var randomY = _number.Next(_boardSize);
            return new Coordinate()
            {
                X = randomX,
                Y = randomY
            };
        }
    }
}