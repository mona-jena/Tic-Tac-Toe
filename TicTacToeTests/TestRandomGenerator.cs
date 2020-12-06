using TicTacToe;

namespace TicTacToeTests
{
    public class TestRandomGenerator : IRandomGenerator
    {
        private string[] _randomNumbers;
        private int _nextNumber;

        public int Next(int max)
        {
            var randomNum = _randomNumbers[_nextNumber++];
            return int.Parse(randomNum);
        }
        
        public void AddNumber(string[] randomNumbers)
        {
            _randomNumbers = randomNumbers;
        }
    }
}