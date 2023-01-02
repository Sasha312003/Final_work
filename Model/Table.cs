namespace Final_work.Model
{
    public class Table
    {
        public int Width { get; private set; } // довжина поля
        public int Height { get; private set; } // висота поля
        public string[,] VirtualTable { get; private set; } // поле для гри
        public readonly string SIGN_X = "x"; // позначка для заповнення поля
        public readonly string SIGN_O = "o"; // позначка для заповнення поля

        public Table() // стандартний розмір 3х3
        {
            Width = 3;
            Height = 3;
            VirtualTable = new string[Width,Height];
            FillTable(); // нумеруємо клітинки поля
        }

        /// <summary>
        /// нумеруємо клітинки поля
        /// </summary>
        public void FillTable()
        {
            int count = 0;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    count++;
                    VirtualTable[x, y] = count.ToString();
                }
            }
        }

        /// <summary>
        /// Метод для отримання розміру поля
        /// </summary>
        /// <returns>Розмір поля</returns>
        public int GetSize()
        {
            return Width * Height;
        }

        /// <summary>
        /// Метод для виводу поля в консоль
        /// </summary>
        public void PrintTable()
        {
            Console.Clear();

            for (int x = 0; x < Width; x++)
            {
                Console.WriteLine();
                for (int y = 0; y < Height; y++)
                {
                    Console.Write(VirtualTable[x,y]);
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для добавлення знака SIGN_O в клітинку поля певного номера
        /// </summary>
        /// <param name="number">Номер клітинки</param>
        public void AddТoughts(int number)
        {
            var y0 = ((number - 1) % 3); // отримання координати y поля
            var x0 = ((number - 1) / 3); // отримання координати x поля
            VirtualTable[x0, y0] = SIGN_O;
        }

        /// <summary>
        /// Метод для добавлення знака SIGN_X в клітинку поля певного номера
        /// </summary>
        /// <param name="number">Номер клітинки</param>
        public void AddCrosse(int number)
        {
            var y0 = ((number - 1) % 3); // отримання координати y поля
            var x0 = ((number - 1) / 3); // отримання координати x поля
            VirtualTable[x0, y0] = SIGN_X;
        }
    }
}
