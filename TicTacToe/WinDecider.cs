using System.Collections.Generic;

//looping is inefficient
//could go to each index - then check horizontal (same ys), vertical (same xs), diagonal (need to check OFB indexes)
//could loop through all index once- get coordinate of all the symbols - check pattern --> complicated
//get players inputs 
//need to store all the inputs
//just go through each input - check horizontal (same ys), vertical (same xs), diagonal (need to check OFB indexes)


namespace TicTacToe
{
    public class WinDecider
    {
        private readonly IList<IWinCondition> _winConditions = new List<IWinCondition>();

        public WinDecider()
        {
            _winConditions.Add(new HorizontalWin());
            _winConditions.Add(new VerticalWin());
            _winConditions.Add(new DiagonalWin());
            _winConditions.Add(new Tie());
        }


        public GameState GetGameState(Board board)
        {
            foreach (var winCondition in _winConditions)
            {
                var gameState = winCondition.HasWon(board);
                if (gameState != GameState.InProgress) return gameState;
            }

            return GameState.InProgress;
        }
    }
}