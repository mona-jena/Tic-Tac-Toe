namespace TicTacToe
{
    public interface IReaderWriter
    {
        void Write(string s);

        string Read();
    }
}