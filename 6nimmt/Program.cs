using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Willkommen zu unserem Spiel-Sammlung!");
            Console.WriteLine("Wähle ein Spiel:");
            Console.WriteLine("1. Tic-Tac-Toe");
            Console.WriteLine("2. Spiel 2 (noch nicht implementiert)");
            Console.WriteLine("3. Spiel 3 (noch nicht implementiert)");
            Console.WriteLine("4. Beenden");
            Console.Write("Deine Wahl: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TicTacToe.Start(); // Вызов игры "Крестики-нолики"
                    break;
                case "2":
                    Console.WriteLine("Spiel 2 ist noch nicht fertig!");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Spiel 3 ist noch nicht fertig!");
                    Console.ReadKey();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Auf Wiedersehen!");
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe! Drücke eine Taste, um es erneut zu versuchen.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
