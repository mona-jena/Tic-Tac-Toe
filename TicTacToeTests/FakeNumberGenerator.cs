using TicTacToe;

namespace TicTacToeTests
{
    public class FakeNumberGenerator : INumberGenerator
    {
        private int _nextNumber;
        private int[] _numbers;

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