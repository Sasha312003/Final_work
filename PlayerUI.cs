using Final_work.Controller;
using Final_work.Model;

namespace Final_work
{
    class PlayerUI
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            string? firstPlayerName;
            string? secondPlayerName;
            const int MINIMUM_LENGTH_NAME = 4; // мінімальний розмір ім'я
            bool isValidateName = false;
            do
            {
                Console.WriteLine("Enter name for first player:");
                firstPlayerName = Console.ReadLine();
                if (string.IsNullOrEmpty(firstPlayerName)) // перевірка на порожнечу
                {
                    Console.WriteLine("Name can not be empty. Repeat please!");
                    continue;
                }
                if (firstPlayerName.Length < MINIMUM_LENGTH_NAME) // перевірка довжини ім'я
                {
                    Console.WriteLine("Name is incorrect. Repeat please!");
                    continue;
                }
                isValidateName = true;

            } while (!isValidateName);

            isValidateName = false;
            do
            {
                Console.WriteLine("Enter name for second player:");
                secondPlayerName = Console.ReadLine();
                if (string.IsNullOrEmpty(secondPlayerName))// перевірка на порожнечу
                {
                    Console.WriteLine("Name can not be empty. Repeat please!");
                    continue;
                }
                if (secondPlayerName.Length < MINIMUM_LENGTH_NAME)// перевірка довжини ім'я
                {
                    Console.WriteLine("Name is incorrect. Repeat please!");
                    continue;
                }
                isValidateName = true;

            } while (!isValidateName);

            var firstPlayerController = new PlayerController(firstPlayerName);
            var secondPlayerController = new PlayerController(secondPlayerName);

            while (true) // бескінечний цикл
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("A - game for two.");
                Console.WriteLine("B - check points.");
                Console.WriteLine("C - check game history.");
                Console.WriteLine("D - exit.");
                var key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key == ConsoleKey.A) // game for two
                {
                    var gameController = new GameController(firstPlayerController.Player,
                        secondPlayerController.Player, new StandardGame()); // создаємо гру
                    var gameResult = gameController.StartGame(); // запускаємо гру 
                    secondPlayerController.AddPoints(gameResult.PointsForSecondPlayer); //добавляємо отриманні поінти
                    firstPlayerController.AddPoints(gameResult.PointsForFirstPlayer); //добавляємо отриманні поінти
                }
                else if (key.Key == ConsoleKey.B) // check points
                {
                    Console.WriteLine($"{firstPlayerController.Player.Name}: ");
                    Console.WriteLine(firstPlayerController.Player.Points);
                    Console.WriteLine($"{secondPlayerController.Player.Name}: ");
                    Console.WriteLine(secondPlayerController.Player.Points);
                }
                else if (key.Key == ConsoleKey.C) // check game history
                {
                    Console.WriteLine($"{firstPlayerController.Player.Name}: ");
                    Console.WriteLine(firstPlayerController.GetHistoryOfGames());
                    Console.WriteLine($"{secondPlayerController.Player.Name}: ");
                    Console.WriteLine(secondPlayerController.GetHistoryOfGames());
                }
                else if (key.Key == ConsoleKey.D) // exit
                {
                    Console.WriteLine("Have fun!");
                    Environment.Exit(0);
                }
                else // other
                {
                    Console.WriteLine("Choice is incorrect. Repeat please!");
                }
            }     
        }
    }
}
