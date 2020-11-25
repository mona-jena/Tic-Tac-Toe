using System;
using System.Globalization;

namespace TicTacToe
{
    public class Player
    {
        private readonly IReaderWriter _readerWriter;
        
        public Player(char symbol, IReaderWriter readerWriter)
        {
            _readerWriter = readerWriter;
        }

        public Coordinate TakeTurn()
        {
            while (true)
            {
                _readerWriter.Write("Enter a coord x,y: ");
                var userSpecifiedCoord = _readerWriter.Read();
                var coordArray = userSpecifiedCoord.Split(",");

                if (coordArray.Length != 2)
                {
                    _readerWriter.Write("Invalid input. Please try again.");
                    continue;
                }
                
                bool ifXIsNumber = int.TryParse(coordArray[0], out var xValue);
                bool ifYIsNumber = int.TryParse(coordArray[1], out var yValue);

                if (ifXIsNumber && ifYIsNumber)
                {
                    return new Coordinate()
                    {
                        X = xValue,
                        Y = yValue
                    };
                }
                
            }
        }
    }
}