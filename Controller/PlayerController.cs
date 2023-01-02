using Final_work.Model;

namespace Final_work.Controller
{
    public class PlayerController : BaseController
    {
        public List<Player> Players { get; private set; }
        public Player Player { get; private set; }

        public PlayerController(string name)
        {
            Players = GetPlayers(); // загружаємо зареєстрованих коричтувачив
            var registredPlayer = Players.SingleOrDefault(x => x.Name == name);
            if (registredPlayer is not null) // якщо користувач зареєстрований 
            {
                Player = registredPlayer;   
            }
            else // якщо не зареєстрований реєструємо
            {
                Player = new Player(name);
                Players.Add(Player);
                Save();
            }
           
        }

        /// <summary>
        /// Метод для додачи поінтів користувачу
        /// </summary>
        /// <param name="points">Кількість поінтів</param>
        public void AddPoints(decimal points)
        {
            Players = GetPlayers();
            Player = Players.Single(x => x.Name == Player.Name);
            Player.Points += points;
            Save();
        }

        /// <summary>
        /// Метод для отримання інформації про ігри
        /// </summary>
        /// <returns>Інформація про ігри</returns>
        public string GetHistoryOfGames()
        {
            var GameHistory = new GameHistory();
            var historyOfGames = GameHistory.GetHistoryOfGames(Player.Name);
            if (!historyOfGames.Any())
            {
                return "Empty.";
            }

            string history = "";
            foreach(var game in historyOfGames)
            {
                history += game.ToString();
                history += Environment.NewLine;
            }

            return history;
        }

        private List<Player> GetPlayers()
        {
            return Load<Player>() ?? new List<Player>();
        }

        private void Save()
        {
            Save(Players);
        }
    }
}
