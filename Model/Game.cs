using System;

namespace Final_work.Model
{
    public class Game
    {
		private GameType _gameInfo; // певний тип гри

		public GameType GameInfo
		{
			get { return _gameInfo; }
			set 
			{
				if (value is null)
				{
					throw new ArgumentException("Game Type can not be null");
				}
                _gameInfo = value; 
			}
		}

		public Game(GameType gameType)
		{
            _gameInfo = gameType;
        }
	}
}
