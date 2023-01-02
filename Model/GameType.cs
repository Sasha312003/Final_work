namespace Final_work.Model
{
    /// <summary>
    /// Абстрактний клас, що описує певний тип гри
    /// </summary>
    public abstract class GameType
    {
        public string GameTypeName { get; protected set; } = "Undefined"; // ім'я типу
        public decimal PointsForWinner { get; protected set; } // поінти що нараховуються переможцю
        public decimal PointsForDraw { get; protected set; } // поінти що нараховуються при нічиї
        public decimal PointsForLoser { get; protected set; } // поінти що нараховуються програвшому
    }
}
