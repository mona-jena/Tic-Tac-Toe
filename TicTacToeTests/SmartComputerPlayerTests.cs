using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class SmartAITests
    {
       [Fact]
       public void SymbolShouldReturnANonNullChar()
       {
           FakeNumberGenerator numberGenerator = new FakeNumberGenerator();
           numberGenerator.AddNumbers(new []{0,0, 1,0, 2,0});
           char player2Symbol = 'O';
           var aiPlayer = new EasyComputerPlayer(numberGenerator, 3, player2Symbol);
           var aiSymbol = aiPlayer.Symbol;
           var expectedSymbol = 'O';
            
           Assert.Equal(expectedSymbol, aiSymbol);
       }
       
       [Fact]
       public void 
    }
    
}