namespace TicTacToe;
using CommunityToolkit.Diagnostics;


public class ConsoleDisplayer : IDisplayer
{
    public void Display(char[] board)
    {
        Guard.HasSizeEqualTo(board, 9);
        for (int i = 0; i < 9; i+=3)
        {
            Console.WriteLine("   |   |");
            Console.WriteLine($" {board[i]} | {board[i + 1]} | {board[i + 2]}");
            Console.WriteLine("   |   |");
            if (i != 6)
            {
                Console.WriteLine("-----------");
            }
        }
    }
}