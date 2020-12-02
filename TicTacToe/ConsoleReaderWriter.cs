using System;
using TicTacToe;

namespace TicTacToeConsoleTests
{
    public class ConsoleReaderWriter : IReaderWriter
    {
        public void Write(string s)
        {
            Console.Write(s);
        }
        

        public string Read()
        {
            return Console.Read().ToString();
        }
    }
}