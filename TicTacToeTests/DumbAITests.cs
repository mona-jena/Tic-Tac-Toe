using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class DumbAITests
    {
        private readonly Player _player;
        private readonly TestReaderWriter _readerWriter;
        private readonly FakeNumberGenerator _numberGenerator;
        
        public DumbAITests()
        {
            _readerWriter = new TestReaderWriter();
            _player = new Player('X', _readerWriter);
            _numberGenerator = new FakeNumberGenerator();
        }
        
        //take symbol through constructor in EasyComputerPlayer and test it here

        [Fact]
        public void TakeTurnShouldReturnRandomPosition() 
        {
            _numberGenerator.AddNumbers(new []{0,0, 1,0, 2,0});
            var aiPlayer = new EasyComputerPlayer(_numberGenerator, 3);
            var firstTurn = aiPlayer.TakeTurn();
            var secondTurn = aiPlayer.TakeTurn();
            var expectedCoord1 = new Coordinate()
            {
                X = 0,
                Y = 0
            };
            var expectedCoord2 = new Coordinate()
            {
                X = 1,
                Y = 0
            };
           
            Assert.Equal(expectedCoord1, firstTurn);
            Assert.Equal(expectedCoord2, secondTurn);
        }
    }
}