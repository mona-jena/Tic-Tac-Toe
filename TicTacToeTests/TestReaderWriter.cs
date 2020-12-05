using TicTacToe;

namespace TicTacToeTests
{
    public class TestReaderWriter : IReaderWriter
    {
        private string[] _userInputs;
        private int _turnNumber;

        public void AddMoves(string[] userInputs)
        {
            _userInputs = userInputs;
        }

        public TestReaderWriter()
        {
            
        }
        
        public void Write(string s)
        {
        }

        public string ReadLine()
        {
            return _userInputs[_turnNumber++];
        }
    }
}