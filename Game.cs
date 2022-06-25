namespace TicTacToe;
public enum Player
{
    X, O
}
public sealed class Game
{
    private readonly char[] _board = new char[9];
    private readonly IDisplayer _displayer;

    public Game(IDisplayer displayer)
    {
        for (int i = 0; i < 9; i++)
        {
            _board[i] = ' ';
        }
        _displayer = displayer;
    }

    private void insert(int pos, Player player) => _board[pos - 1] = player == Player.X ? 'X' : 'O';

    private bool isPosAvailable(int pos) => _board[pos - 1] == ' ';

    public void Start()
    {
        _displayer.Display(_board);
    }
}