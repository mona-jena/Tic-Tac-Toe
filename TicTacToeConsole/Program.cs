using TicTacToe;

namespace TicTacToeConsole
{
    internal static class Program
    {
        private static void Main()
        {
            var consoleReaderWriter = new ConsoleReaderWriter();
            consoleReaderWriter.Write("What size board would you like to play with? ");
            var boardSize = int.Parse(consoleReaderWriter.ReadLine().Trim());
            var board = new Board(boardSize);
;
            var charPlayer1Symbol = '.';
            while (charPlayer1Symbol == '.')
            {
                consoleReaderWriter.Write("Player 1, what symbol would you like to be? ");
                var player1Symbol = consoleReaderWriter.ReadLine().Trim();
                charPlayer1Symbol = char.Parse(player1Symbol);
            }

            var player1 = new Player(charPlayer1Symbol, consoleReaderWriter);
            
            Player player2 = new Player();
            EasyComputerPlayer easyComputer = new EasyComputerPlayer();
            SmartComputerPlayer smartComputer = new SmartComputerPlayer();
            consoleReaderWriter.Write(
                "\nWould you like to play with (1) another player or (2) computer \nChoose option: ");
            var playerOption = consoleReaderWriter.ReadLine().Trim();
            var charPlayer2Symbol = charPlayer1Symbol;
            if (playerOption == "1")
            {
                while (charPlayer2Symbol == '.' || charPlayer2Symbol == charPlayer1Symbol)
                {
                    consoleReaderWriter.Write("Player 2, what symbol would you like to be? ");
                    var player2Symbol = consoleReaderWriter.ReadLine().Trim();
                    charPlayer2Symbol = char.Parse(player2Symbol);
                }
                
                player2 = new Player(charPlayer2Symbol, consoleReaderWriter);
                
            }
            else if (playerOption == "2")
            {
                consoleReaderWriter.Write("\nWhat mode would you like to play in (1)Easy or (2)Hard \nChoose option: ");
                var modeLevel = consoleReaderWriter.ReadLine().Trim();
                if (modeLevel == "1")
                {
                    while ((charPlayer2Symbol == '.') | (charPlayer2Symbol == charPlayer1Symbol))
                    {
                        consoleReaderWriter.Write("Please choose a different symbol for the computer player: ");
                        var player2Symbol = consoleReaderWriter.ReadLine().Trim();
                        charPlayer2Symbol = char.Parse(player2Symbol);
                    }
                    
                    //easyComputer = new EasyComputerPlayer(new FakeNumberGenerator(),boardSize, charPlayer2Symbol);
                }
                else if (modeLevel == "2")
                {
                    while ((charPlayer2Symbol == '.') | (charPlayer2Symbol == charPlayer1Symbol))
                    {
                        consoleReaderWriter.Write("Please choose a different symbol for the computer player: ");
                        var player2Symbol = consoleReaderWriter.ReadLine().Trim();
                        charPlayer2Symbol = char.Parse(player2Symbol);
                    }
                    
                    smartComputer = new SmartComputerPlayer(charPlayer2Symbol,charPlayer1Symbol, board);
                }
                
            }

            var game = new Game(player1, player2, board, consoleReaderWriter);
            game.PLay();
        }
    }
}