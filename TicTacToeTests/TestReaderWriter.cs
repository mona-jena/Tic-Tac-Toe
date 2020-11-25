using TicTacToe;

namespace TicTacToeTests
{
    public class TestReaderWriter : IReaderWriter
    {
        private string[] _userInputs;
        private int _turnNumber;

        public TestReaderWriter(string[] userInputs)
        {
            _userInputs = userInputs;
        }

        public void Write(string s)
        {
        }

        public string Read()
        {
            return _userInputs[_turnNumber++];
        }
    }
}