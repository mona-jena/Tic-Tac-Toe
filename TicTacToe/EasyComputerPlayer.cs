namespace TicTacToe
{
    public class EasyComputerPlayer : IPlayer
    {
        private readonly int _boardSize;
        private readonly INumberGenerator _number;

        public EasyComputerPlayer(INumberGenerator number, int boardSize, char aiSymbol)
        {
            _number = number;
            _boardSize = boardSize;
            Symbol = aiSymbol;
        }

        public char Symbol { get; }

        public Coordinate TakeTurn()
        {
            var randomX = _number.Next(_boardSize);
            var randomY = _number.Next(_boardSize);
            return new Coordinate
            {
                X = randomX,
                Y = randomY
            };
        }
    }
}