using System.ComponentModel;
using Final_work.Model;

namespace Final_work.Controller
{
    public class GameHistory : BaseController
    {
        private List<GameResult> HistoryOfGames;

        public GameHistory()
        {
            HistoryOfGames = GetHistoryOfGames();
        }
        
        // метод для добавлення інформації про гру
        public void Add(GameResult gameResult)
        {
            HistoryOfGames.Add(gameResult);
            Save();
        }

        // метод для отримання листу зі зіграними іграми гравця з певним ім'я
        public List<GameResult> GetHistoryOfGames(string name)
        {
            var winner = HistoryOfGames.Where(x => x.FirstPlayerName == name).ToList();
            var loser = HistoryOfGames.Where(x => x.SecondPlayerName == name).ToList();
            var list = new List<GameResult>();
            list.AddRange(winner);
            list.AddRange(loser);
            return list;
        }

        private List<GameResult> GetHistoryOfGames()
        {
            return Load<GameResult>();
        }

        private void Save()
        {
            Save<GameResult>(HistoryOfGames);
        }
    }
}
