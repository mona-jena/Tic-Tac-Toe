using System;
using TicTacToe;

namespace TicTacToeConsoleTests
{
    public class ConsoleReaderWriter : IReaderWriter
    {
        public void Write(string s)
        {
            Console.WriteLine(s);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}