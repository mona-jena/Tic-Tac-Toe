using TicTacToe;

namespace TicTacToeTests
{
    public class FakeNumberGenerator : INumberGenerator
    {
        private int[] _numbers;
        private int _nextNumber;

        public int Next(int max)
        {
            var number = _numbers[_nextNumber++];
            return number;
        }
        
        public void AddNumbers(int[] numbers)
        {
            _numbers = numbers;
        }
    }
}