using NuGet.Frameworks;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class DumbAITests
    {
        private readonly Player _player;
        private readonly TestReaderWriter _readerWriter;
        private readonly TestRandomGenerator _randomGenerator;
        
        public DumbAITests()
        {
            _player = new Player('X', _readerWriter);
            _readerWriter = new TestReaderWriter();
            _randomGenerator = new TestRandomGenerator();
        }
        
        [Fact]
        public void ChooseSymbolShouldBeAbleToPickSymbolNotChosenByPLayer()
        {
            _readerWriter.AddMoves(new[] {"0,0", "1,0", "2,0"});
            _randomGenerator.AddNumber(new []{"0,0", "1,1", "2,1", "3,1", "0,1" });
            var aiPlayer = new DumbAI(_randomGenerator);
            /*var game = new Game(_player, aiPlayer, 3, new TestReaderWriter());
            game.PLay();*/
            
            var pickedSymbol = aiPlayer.ChooseSymbol();
            
            var expectedSymbol = 'O';
            
            Assert.Equal(expectedSymbol, pickedSymbol);
        }

        /*[Fact]
        public void TakeTurnShouldReturnRandomPosition()
        {
            
        }*/
    }
}