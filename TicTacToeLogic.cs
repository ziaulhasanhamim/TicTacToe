namespace TicTacToe;

public sealed class TicTacToeLogic
{
    public TicTacToeLogic()
    {
        for (int i = 0; i < 9; i++)
        {
            Board[i] = ' ';
        }
    }

    public char[] Board { get; } = new char[9];

    public Player NextMovePlayer { get; private set; }

    public bool IsBoardFull() => !Board.Any(c => c == ' ');

    public void Insert(int pos) => Board[pos - 1] = changeNextMovePlayer() == Player.X ? 'X' : 'O';

    public bool IsPosAvailable(int pos) => pos > 0 && pos < 10 && Board[pos - 1] == ' ';

    public Player? AnyWin()
    {
        Player? winner = null;

        horizontalWinCheck(ref winner);
        verticleWinCheck(ref winner);
        diagonalWinCheck(ref winner);

        return winner;
    }

    void diagonalWinCheck(ref Player? winner)
    {
        if (Board[0] != ' ' && Board[0] == Board[4] && Board[4] == Board[8])
        {
            winner = Board[0] switch
            {
                'X' => Player.X,
                'O' => Player.O,
                _ => throw new ArgumentException()
            };
        }
        if (Board[2] != ' ' && Board[2] == Board[4] && Board[4] == Board[6])
        {
            winner = Board[2] switch
            {
                'X' => Player.X,
                'O' => Player.O,
                _ => throw new ArgumentException()
            };
        }
    }

    void verticleWinCheck(ref Player? winner)
    {
        for (int i = 0; i < 3; i++)
        {
            if (Board[i] != ' ' && Board[i] == Board[i + 3] && Board[i + 3] == Board[i + 6])
            {
                winner = Board[i] switch
                {
                    'X' => Player.X,
                    'O' => Player.O,
                    _ => throw new ArgumentException()
                };
                return;
            }
        }
    }

    void horizontalWinCheck(ref Player? winner)
    {
        for (int i = 0; i < 9; i += 3)
        {
            if (Board[i] != ' ' && Board[i] == Board[i + 1] && Board[i + 1] == Board[i + 2])
            {
                winner = Board[i] switch
                {
                    'X' => Player.X,
                    'O' => Player.O,
                    _ => throw new ArgumentException()
                };
                return;
            }
        }
    }

    Player changeNextMovePlayer()
    {
        var prev = NextMovePlayer;
        NextMovePlayer = prev switch 
        {
            Player.X => Player.O,
            Player.O => Player.X,
            _ => throw new ArgumentException()
        };
        return prev;
    }
}