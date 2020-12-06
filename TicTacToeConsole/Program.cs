using TicTacToe;

namespace TicTacToeConsole
{
    internal static class Program
    {
        private static void Main()
        {
            var consoleReaderWriter = new ConsoleReaderWriter();
            consoleReaderWriter.Write("What size board would you like to play with? ");
            var boardSize = int.Parse(consoleReaderWriter.ReadLine());
            
            // would you like to play with a friend or with the computer?
            
            // if comp:
                // create AI player object with 'X' symbol --> it becomes Player1
                // prompt player what symbol the AI has chosen
                
            // ask player what symbol to play --> Human player becomes Player2
                // if they choose same symbol as AI then ask again
                // create player2 object 


            consoleReaderWriter.Write("Player 1, what symbol would you like to be? ");
            var player1Symbol = consoleReaderWriter.ReadLine();
            var player1 = new Player(char.Parse(player1Symbol), consoleReaderWriter);

            consoleReaderWriter.Write("Player 2, what symbol would you like to be? ");
            var player2Symbol = consoleReaderWriter.ReadLine();
            var player2 = new Player(char.Parse(player2Symbol), consoleReaderWriter);

            var game = new Game(player1, player2, boardSize, consoleReaderWriter);
            game.PLay();
        }
    }
}