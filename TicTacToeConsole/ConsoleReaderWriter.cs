using System;
using TicTacToe;

namespace TicTacToeConsole
{
    public class ConsoleReaderWriter : IReaderWriter
    {
        public void Write(string s)
        {
            Console.Write(s);
        }
        

        public string ReadLine()
        {
            return Console.ReadLine();
        }
        
    
    }
}