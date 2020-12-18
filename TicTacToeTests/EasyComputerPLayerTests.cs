using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class EasyComputerPlayerTests
    {

        [Fact]
        public void SymbolShouldReturnANonNullChar()
        {
            var numberGenerator = new FakeNumberGenerator();
            numberGenerator.AddNumbers(new[] {0, 0, 1, 0, 2, 0});
            var player2Symbol = 'O';
            var aiPlayer = new EasyComputerPlayer(numberGenerator, 3, player2Symbol);
            var aiSymbol = aiPlayer.Symbol;
            var expectedSymbol = 'O';

            Assert.Equal(expectedSymbol, aiSymbol);
        }

        [Fact]
        public void TakeTurnShouldReturnRandomPosition()
        {
            var numberGenerator = new FakeNumberGenerator();
            numberGenerator.AddNumbers(new[] {0, 0, 1, 0, 2, 0});
            var player2Symbol = 'O';
            var aiPlayer = new EasyComputerPlayer(numberGenerator, 3, player2Symbol);
            var firstTurn = aiPlayer.TakeTurn();
            var secondTurn = aiPlayer.TakeTurn();
            var expectedCoord1 = new Coordinate
            {
                X = 0,
                Y = 0
            };
            var expectedCoord2 = new Coordinate
            {
                X = 1,
                Y = 0
            };

            Assert.Equal(expectedCoord1, firstTurn);
            Assert.Equal(expectedCoord2, secondTurn);
        }
    }
}