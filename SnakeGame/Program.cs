namespace SnakeGame
{
    internal class Program
    {
        private const int ScreenWidth = 40;
        private const int ScreenHeight = 20;

        static void Main(string[] args)
        {
            Console.Title = "Snake Game - Projekt Wspólny";
            Console.CursorVisible = false;

            try
            {
                Console.WindowWidth = ScreenWidth;
                Console.WindowHeight = ScreenHeight;
                Console.BufferWidth = ScreenWidth;
                Console.BufferHeight = ScreenHeight;
            }
            catch
            {
                // Niektóre terminale nie pozwalają zmienić rozmiaru okna.
            }

            ShowMenu();
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== SNAKE GAME ===");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("1 - Graj solo (strzałki)");
            Console.WriteLine("2 - Graj wieloosobowo (P1: strzałki, P2: WASD)");
            Console.WriteLine("3 - Wyjście");
            Console.WriteLine();
            Console.Write("Wybierz tryb: ");

            ConsoleKeyInfo choice = Console.ReadKey(intercept: true);

            switch (choice.KeyChar)
            {
                case '1':
                    RunSinglePlayer();
                    break;
                case '2':
                    RunMultiPlayer();
                    break;
                default:
                    return;
            }
        }

        private static void RunSinglePlayer()
        {
            Game game = new(ScreenWidth, ScreenHeight);
            game.AddPlayer(new Snake(
                ScreenWidth / 2,
                ScreenHeight / 2,
                ConsoleColor.Green,
                "Gracz 1"));

            game.Run();
            ShowMenu();
        }

        private static void RunMultiPlayer()
        {
            Game game = new(ScreenWidth, ScreenHeight);
            game.AddPlayer(new Snake(
                ScreenWidth / 3,
                ScreenHeight / 2,
                ConsoleColor.Green,
                "Gracz 1 (strzałki)"));

            game.AddPlayer(new Snake(
                (ScreenWidth / 3) * 2,
                ScreenHeight / 2,
                ConsoleColor.Magenta,
                "Gracz 2 (WASD)",
                "LEFT"));

            game.Run();
            ShowMenu();
        }
    }
}
