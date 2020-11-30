using TicTacToe;

namespace TicTacToeConsoleTests
{
    public class ConsoleReaderWriter : IReaderWriter
    {
        
        private string[] _userInputs;

        public ConsoleReaderWriter(string[] userInputs)
        {
            _userInputs = userInputs;
        }
        public void Write(string s)
        {
            throw new System.NotImplementedException();
        }

        public string Read()
        {
            throw new System.NotImplementedException();
        }
    }
}