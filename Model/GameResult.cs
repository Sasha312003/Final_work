namespace Final_work.Model
{
    /// <summary>
    /// Клас, що описує результат гри
    /// </summary>
    public class GameResult
    {
        public string FirstPlayerName { get; set; } 
        public string SecondPlayerName { get; set; }
        public decimal PointsForFirstPlayer { get; set; } // поінти що отримав перший гравець
        public decimal PointsForSecondPlayer { get; set; } // поінти що отримав другий гравець

        public GameResult()
        {
            FirstPlayerName = "Undefined";
            SecondPlayerName = "Undefined";
        }

        public GameResult(string firstPlayerName, string secondPlayerName, 
            decimal pointsForFirstPlayer, decimal pointsForSecondPlayer)
        {
            FirstPlayerName = firstPlayerName;
            SecondPlayerName = secondPlayerName;
            PointsForFirstPlayer = pointsForFirstPlayer;
            PointsForSecondPlayer = pointsForSecondPlayer;
        }

        public override string ToString() // переоприділяємо метод ToString() 
        {
            return $"Game: {FirstPlayerName} vs {SecondPlayerName}. " +
                $"Points For {FirstPlayerName}: {PointsForFirstPlayer}. " +
                $"Points For {SecondPlayerName}: {PointsForSecondPlayer}";
        }
    }
}
