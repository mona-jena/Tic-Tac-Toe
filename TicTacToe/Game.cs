using System;

namespace TicTacToe
{
    public class Game
    {
        private Board _board;

        public Game(Player player1, Player player2)
        {
            _board = new Board(3);
        }

        public GameState GetState()
        {
            var winDecider = new WinDecider();
            var gameState = winDecider.GetGameState(_board);
            return gameState;
        }


        public string PrintBoard()
        {
            throw new NotImplementedException();
        }

        public Player GetCurrentPlayer()
        {
            throw new NotImplementedException();
        }

        public void DoNextTurn()
        {
            /*
                 * Player take turn
                 * check if valid; if not repeat loop
                 * place on the board
                 * check for winner - if winner exit loop
                 * change Player
                 * continue loop
            */
            
        }

       
    }
}