using System;

class TicTacToe
{
    private static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    public static void Start()
    {
        int currentPlayer = 1; // 1 - X, 2 - O
        bool gameRunning = true;

        while (gameRunning)
        {
            Console.Clear();
            PrintBoard();

            Console.WriteLine($"Spieler {currentPlayer} ({(currentPlayer == 1 ? 'X' : 'O')}), dein Zug: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
            {
                if (MakeMove(currentPlayer, position))
                {
                    if (CheckWin())
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine($"Spieler {currentPlayer} gewinnt!");
                        gameRunning = false;
                    }
                    else if (CheckDraw())
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine("Unentschieden!");
                        gameRunning = false;
                    }
                    else
                    {
                        currentPlayer = 3 - currentPlayer; // Wechsel Spieler
                    }
                }
                else
                {
                    Console.WriteLine("Dieses Feld ist bereits besetzt! Drücke eine Taste, um fortzufahren.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe! Drücke eine Taste, um fortzufahren.");
                Console.ReadKey();
            }
        }
        Console.WriteLine("Drücke eine Taste, um zum Menü zurückzukehren.");
        Console.ReadKey();
        ResetBoard(); // Обновление доски для новой игры
    }

    private static void PrintBoard()
    {
        Console.WriteLine(" " + board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" " + board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" " + board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2]);
    }

    private static bool MakeMove(int player, int position)
    {
        char mark = player == 1 ? 'X' : 'O';
        (int row, int col) = GetRowCol(position);

        if (board[row, col] != 'X' && board[row, col] != 'O')
        {
            board[row, col] = mark;
            return true;
        }
        return false;
    }

    private static (int, int) GetRowCol(int position)
    {
        position -= 1;
        return (position / 3, position % 3);
    }

    private static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) return true; // Reihen
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i]) return true; // Spalten
        }
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) return true; // Diagonale \
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) return true; // Diagonale /
        return false;
    }

    private static bool CheckDraw()
    {
        foreach (char cell in board)
        {
            if (cell != 'X' && cell != 'O') return false;
        }
        return true;
    }

    private static void ResetBoard()
    {
        board = new char[,] {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };
    }
}
