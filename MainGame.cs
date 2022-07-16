namespace TicTacToe;

using System;
using CommunityToolkit.Diagnostics;


public class MainGame
{
    private readonly TicTacToeLogic _ticTacToe = new();

    public void Start()
    {
        Console.WriteLine("Welcome to Tic tac toe.");
        printBoard(_ticTacToe.Board);
        while (!_ticTacToe.IsBoardFull())
        {
            var winner = _ticTacToe.AnyWin();
            if (winner is not null)
            {
                Console.WriteLine($"Player {winner.Value} won the game.");
                break;
            }
            playerInput();
            printBoard(_ticTacToe.Board);
        }
    }

    private void playerInput()
    {
        Console.WriteLine($"Player {_ticTacToe.NextMovePlayer} please Choose a position from 1-9 which was not used before.");
        
        while (true)
        {
            Console.Write("> ");
            var line = Console.ReadLine();
            if (int.TryParse(line, out var position) && _ticTacToe.IsPosAvailable(position))
            {
                _ticTacToe.Insert(position);
                return;
            }
            Console.WriteLine($"Wrong input. Choose a position from 1-9 which was not used before.");
        }
    }

    private static void printBoard(char[] board)
    {
        for (int i = 0; i < 9; i += 3)
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