namespace TicTacToe
{
    public class DumbAI : IPlayer
    {
        private readonly IRandomGenerator _random;
        private readonly int _boardSize;
        public char Symbol { get; private set; }

        public DumbAI(IRandomGenerator random, int boardSize)
        {
            _random = random;
            _boardSize = boardSize;
            ChooseSymbol();
        }
        
        private void ChooseSymbol()
        {
           //could get AI to choose symbol first, and then ask player for symbol --> if they select same symbol get hem to enter again
           Symbol = 'X';
        }
         
            
        public Coordinate TakeTurn()
        {
            
            throw new System.NotImplementedException();
        }
    }
}