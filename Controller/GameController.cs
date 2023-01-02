using Final_work.Model;

namespace Final_work.Controller
{
    public class GameController
    {
        public Game Game { get; private set; }
        public GameHistory GameHistory { get; private set; }
        public Table Table { get; private set; }
        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }

        public GameController(Player firstPlayer, Player secondPlayer, GameType gameType)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            Game = new Game(gameType);
            Table = new Table();
            GameHistory = new GameHistory();
        }

        /// <summary>
        /// Метод, що реалізує гру крестики нолики
        /// </summary>
        /// <returns>Результат гри</returns>
        public GameResult StartGame()
        {
            Table.PrintTable(); // вивід поля
            Console.WriteLine($"{FirstPlayer.Name} - x."); // надання ролі
            Console.WriteLine($"{SecondPlayer.Name} - o."); // надання ролі
            Console.WriteLine($"First Step - {FirstPlayer.Name}."); // надання першого ходу
            bool isWinner = false; // поле для перевірки чи є переможець в грі
            GameResult gameResult = new GameResult(); // поле для результату гри
            // граємо пока є незаповнені клітинки, або не буде визначено перемощця
            for (int stepNumber = 1; stepNumber <= Table.GetSize(); stepNumber++) 
            {
                Step(stepNumber); // гравець робить ход
                Table.PrintTable(); // вивід нового поля
                if (IsWin()) // перевірка ход завершився перемогою
                {
                    if (stepNumber % 2 == 1) // перевірка який гравець виграв
                    {
                        Console.WriteLine("Game Over!");
                        Console.WriteLine($"Winner - {FirstPlayer.Name}");
                        gameResult = new GameResult(FirstPlayer.Name, SecondPlayer.Name,
                            Game.GameInfo.PointsForWinner, Game.GameInfo.PointsForLoser); // запис результату гри
                    }
                    else
                    {
                        Console.WriteLine("Game Over!");
                        Console.WriteLine($"Winner - {SecondPlayer.Name}");
                        gameResult = new GameResult(FirstPlayer.Name, SecondPlayer.Name,
                               Game.GameInfo.PointsForLoser, Game.GameInfo.PointsForWinner);// запис результату гри
                    }
                   
                    isWinner = true; 
                    break;
                }
            }

            if (!isWinner) // якщо немає переможця
            {
                gameResult = new GameResult(FirstPlayer.Name, SecondPlayer.Name,
                             Game.GameInfo.PointsForDraw, Game.GameInfo.PointsForDraw);// запис результату гри
                Console.WriteLine("Game Over! Draw!");
            }

            GameHistory.Add(gameResult); // добавлення результату гри в історію ігор
            return gameResult; // повертаємо результат
        }

        public void Step(int stepNumber)
        {
            var cellNumber = GetCellNumber(); // отримуємо номер клітинки від гравця
            if (stepNumber % 2 == 1)
            {
                Table.AddCrosse(cellNumber); // запис х в певну клітинку
            }
            else
            {
                Table.AddТoughts(cellNumber); // запис о в певну клітинку
            }
        } 

        public bool IsWin() // перевірка чи є переможець
        {
            if (CheckCols() || CheckRows() || CheckLeftGorizontal() || CheckRightGorizontal())
            {
                return true;
            }
           
            return false;
        }

        // перевірка перемоги по строкам
        public bool CheckRows() 
        {
            bool checkRow;

            for (int row = 0; row < Table.Height; row++)
            {
                checkRow = true;
                for (int col = 0; col < Table.Width - 1; col++)
                {
                    if (Table.VirtualTable[row,col] != Table.VirtualTable[row, col + 1])
                    {
                        checkRow = false;
                        break;
                    } 
                }
               if (checkRow)
               {
                    return true;
               }
            }

            return false; 
        }

        // перевірка перемоги по колонкам
        public bool CheckCols()
        {
            bool checkCol;

            for (int row = 0; row < Table.Height; row++)
            {
                checkCol = true;
                for (int col = 0; col < Table.Width - 1; col++)
                {
                    if (Table.VirtualTable[col, row] != Table.VirtualTable[col + 1, row ])
                    {
                        checkCol = false;
                        break;
                    }
                }
                if (checkCol)
                {
                    return true;
                }
            }

            return false;
        }

        // перевірка перемоги по горизонталі( з зліва на право)
        public bool CheckLeftGorizontal()
        {
            for (int cor = 0; cor < Table.Height - 1; cor++)
            {
                if (Table.VirtualTable[cor, cor] != Table.VirtualTable[cor + 1, cor + 1])
                {
                    return false;
                }
            }

            return true;
        }

        // перевірка перемоги по горизонталі( з права на ліво)
        public bool CheckRightGorizontal()
        {
            for (int cor = 0; cor < Table.Height - 1; cor++)
            {
                if (Table.VirtualTable[cor, Table.Height - cor - 1] != Table.VirtualTable[cor + 1, Table.Height - cor - 2])
                {
                    return false;
                }
            }

            return true;
        }

        //отримання номера клітинки
        public int GetCellNumber()
        {
            bool isValidateNumber = false;
            int cellNumber = 0;
            do
            {
                Console.WriteLine($"Enter number of cell (1 - {Table.GetSize()} ): ");
                try
                {
                    cellNumber = int.Parse(Console.ReadLine());
                }
                catch // якщо введено не цифру
                {
                    Console.WriteLine("Number is incorrect. Repeat please!");
                    continue;
                }

                if (cellNumber > Table.GetSize() || cellNumber <= 0) // якщо не задовільняє розмір поля
                {
                    Console.WriteLine("Number is incorrect. Repeat please!");
                    continue;
                }

                var y0 = ((cellNumber - 1) % 3); // отримуємо координату у
                var x0 = ((cellNumber - 1) / 3); // отримуємо координату х
                // перевірка чи поле ще не використане
                if (Table.VirtualTable[x0, y0] == Table.SIGN_O || Table.VirtualTable[x0, y0] == Table.SIGN_X)
                {
                    Console.WriteLine("Number is incorrect. Repeat please!");
                    continue;
                }

                isValidateNumber = true;

            } while (!isValidateNumber);

            return cellNumber;
        }
    }
}
