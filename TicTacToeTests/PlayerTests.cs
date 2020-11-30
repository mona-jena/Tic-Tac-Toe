using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class PlayerTests
    {
        [Fact]
        public void TakeTurnShouldTakeSecondUserInputAndReturnTheSpecifiedCoord()
        {
            var readerWriter = new TestReaderWriter(new []{"1,1", "1,2", "1,3"});
            var player = new Player('X', readerWriter);
            var userSpecifiedCoord = player.TakeTurn();
            userSpecifiedCoord = player.TakeTurn();
            Coordinate expectedCoord = new Coordinate()
            {
                X = 1,
                Y = 2
            };

            Assert.Equal(expectedCoord, userSpecifiedCoord);
        }
        
        [Fact]
        public void TakeTurnShouldTakeUserInputAndReturnTheSpecifiedCoord2()
        {
            var readerWriter = new TestReaderWriter(new []{"bb", "1,2", "aaa"});
            var player = new Player('X', readerWriter);
            var userSpecifiedCoord = player.TakeTurn();
            Coordinate expected = new Coordinate()
            {
                X = 1,
                Y = 2
            };

            Assert.Equal(expected, userSpecifiedCoord);
        }
        
        [Fact]
        public void TakeTurnShouldTakeUserInputAndReturnTheSpecifiedCoord3()
        {
            var readerWriter = new TestReaderWriter(new []{"1,bb", "1,2", "aaa"});
            var player = new Player('X', readerWriter);
            var userSpecifiedCoord = player.TakeTurn();
            Coordinate expected = new Coordinate()
            {
                X = 1,
                Y = 2
            };

            Assert.Equal(expected, userSpecifiedCoord);
        }
        
        [Fact]
        public void TakeTurnShouldTakeUserInputAndReturnTheSpecifiedCoord4()
        {
            var readerWriter = new TestReaderWriter(new []{"1,2,3", "1,2", "aaa"});
            var player = new Player('X', readerWriter);
            var userSpecifiedCoord = player.TakeTurn();
            Coordinate expected = new Coordinate()
            {
                X = 1,
                Y = 2
            };

            Assert.Equal(expected, userSpecifiedCoord);
        }
        
        
    }
}