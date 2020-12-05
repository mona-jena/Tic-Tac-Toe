using TicTacToe;

namespace TicTacToeTests
{
    public class TestReaderWriter : IReaderWriter
    {
        private int _turnNumber;
        private string[] _userInputs;

        public void Write(string s)
        {
        }

        public string ReadLine()
        {
            return _userInputs[_turnNumber++];
        }

        public void AddMoves(string[] userInputs)
        {
            _userInputs = userInputs;
        }
    }
}