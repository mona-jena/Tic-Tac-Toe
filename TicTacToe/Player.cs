using System;

namespace TicTacToe
{
    public class Player : IPlayer
    {
        private readonly IReaderWriter _readerWriter;

        public Player(char symbol, IReaderWriter readerWriter)
        {
            Symbol = symbol;
            _readerWriter = readerWriter ?? throw new ArgumentException(nameof(readerWriter));
        }

        public char Symbol { get; }

        public Coordinate TakeTurn()
        {
            while (true)
            {
                _readerWriter.Write(Symbol + " Enter a coord x,y: ");
                var userSpecifiedCoord = _readerWriter.ReadLine();
                var coordArray = userSpecifiedCoord.Split(",");

                if (coordArray.Length != 2)
                {
                    _readerWriter.Write("Invalid input. Please try again.");
                    continue;
                }

                var ifXIsNumber = int.TryParse(coordArray[0], out var xValue);
                var ifYIsNumber = int.TryParse(coordArray[1], out var yValue);

                if (ifXIsNumber && ifYIsNumber)
                    return new Coordinate
                    {
                        X = xValue,
                        Y = yValue
                    };
            }
        }
    }
}