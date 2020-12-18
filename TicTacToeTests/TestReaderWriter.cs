using System;
using System.Linq;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestReaderWriter : IReaderWriter
    {
        private int _turnNumber;
        private string[] _userInputs;
        public string _userOutputs { get; private set; } = string.Empty;

        public void Write(string s)
        {
            _userOutputs += s;
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