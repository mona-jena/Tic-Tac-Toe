using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class PlayerTests
    {
        private readonly Player _player;
        private readonly TestReaderWriter _readerWriter;

        public PlayerTests()
        {
            _readerWriter = new TestReaderWriter();
            _player = new Player('X', _readerWriter);
        }


        [Fact]
        public void TakeTurnShouldTakeSecondUserInputAndReturnTheSpecifiedCoordAfterSecondTurn()
        {
            _readerWriter.AddMoves(new[] {"1,1", "1,2", "1,3"});
            var userSpecifiedCoord = _player.TakeTurn();
            userSpecifiedCoord = _player.TakeTurn();
            var expectedCoord = new Coordinate
            {
                X = 1,
                Y = 2
            };

            Assert.Equal(expectedCoord, userSpecifiedCoord);
        }

        [Fact]
        public void TakeTurnShouldIgnoreUserInputThatDoesNotSpecifyXAndY()
        {
            _readerWriter.AddMoves(new[] {"bb", "1,2", "aaa"});
            var userSpecifiedCoord = _player.TakeTurn();
            var expected = new Coordinate
            {
                X = 1,
                Y = 2
            };

            Assert.Equal(expected, userSpecifiedCoord);
        }

        [Fact]
        public void TakeTurnShouldIgnoreUserInputIfItsNotAnInteger()
        {
            _readerWriter.AddMoves(new[] {"1,bb", "1,2", "aaa"});
            var userSpecifiedCoord = _player.TakeTurn();
            var expected = new Coordinate
            {
                X = 1,
                Y = 2
            };

            Assert.Equal(expected, userSpecifiedCoord);
        }

        [Fact]
        public void TakeTurnShouldIgnoreUserInputIfTwoInputsAreNotExactlyGiven()
        {
            _readerWriter.AddMoves(new[] {"1,2,3", "1,2", "aaa"});
            var userSpecifiedCoord = _player.TakeTurn();
            var expected = new Coordinate
            {
                X = 1,
                Y = 2
            };

            Assert.Equal(expected, userSpecifiedCoord);
        }
    }
}