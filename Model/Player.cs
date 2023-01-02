namespace Final_work.Model
{
    /// <summary>
    /// Клас, що описує гравця
    /// </summary>
    public class Player
    {
		private string _name; // ім'я гравця
        public decimal Points { get; set; } // поінти гравця
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be empty.");
                }
                _name = value;
            }
        }
		public Player()
		{
			_name = "Undefined";
		}

		public Player(string name)
		{
			Name = name;
            Points = 0;
		}

	}
}
