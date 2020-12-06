namespace TicTacToe
{
    public class DumbAI : IPlayer
    {
        private readonly IRandomGenerator _random;
        public char Symbol { get; }

        public DumbAI(IRandomGenerator random)
        {
            _random = random;
        }
        
        public char ChooseSymbol()
        {
            //gets chosen after game created
            //need to set at start of first turn of AIPlayer
        }
        
            
        public Coordinate TakeTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}