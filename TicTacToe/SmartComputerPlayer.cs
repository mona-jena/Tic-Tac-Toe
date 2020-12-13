using System.Collections.Generic;

namespace TicTacToe
{
    public class SmartComputerPlayer : IPlayer
    {
        public char Symbol { get; }
        
        public SmartComputerPlayer(char symbol, List<Coordinate> humanPlayerCoords)
        {
            Symbol = symbol;
        }

        public Coordinate TakeTurn()
        {
            throw new System.NotImplementedException();
        }
        
        
    }
}