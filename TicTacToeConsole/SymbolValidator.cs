using System.Collections.Generic;

namespace TicTacToeConsole
{
    internal class SymbolValidator
    {
        private readonly List<char> _symbolOption = new List<char>() {'O', 'A', 'C', 'Y', 'S'};
     
        public char IsValid(char player1Symbol)
        {
            char player2Symbol = ' ';
 
            foreach (var i in _symbolOption)
            {
                if (player1Symbol != i)
                {
                    player2Symbol = i;
                    break;
                }
            }

            return player2Symbol;
        }
    }
}