namespace Final_work.Model
{
    public class StandardGame : GameType // наслідуєм абстрактний клас GameType
    {
        public StandardGame() // задання інформації про StandardGame(один із видів гри)
        {
            GameTypeName = "Standard Game";
            PointsForWinner = 10;
            PointsForDraw = 1;
            PointsForLoser = 4;
        }
    }
}
