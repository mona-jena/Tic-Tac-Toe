using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class SmartComputerPlayerTests
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
       public void BlockPossibleHorizontalWin()
       {
           var humanPlayerCoords = new List<Coordinate>();
           humanPlayerCoords.Add(new Coordinate {X = 1, Y = 0});
           humanPlayerCoords.Add(new Coordinate {X = 1, Y = 1});
           var smartComputerPlayer = new SmartComputerPlayer('O', humanPlayerCoords);

           //smartComputerPlayer.BlockHorizontalWin();
           var smartPlayerTurn = smartComputerPlayer.TakeTurn();
           var expectedCoord = new Coordinate {X = 1, Y = 2};
           Assert.Equal(expectedCoord, smartPlayerTurn);

       }
    }
    
}