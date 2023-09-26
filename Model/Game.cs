namespace Model
{
    public class Game
    {
        private int _gameCode;
        private string _name = "";
        private DateTime _releaseDate;
        private string _genre = "";
        private string _description = "";
        private bool _haveExpansion;

        public int GameCode { get => _gameCode; set => _gameCode = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public bool HaveExpansion { get => _haveExpansion; set => _haveExpansion = value; }
        public double AgeInDays { get => (Math.Floor((DateTime.Now - _releaseDate).TotalDays)); } //Implementação do cálculo pedido com DateTime.
        public string Genre { get => _genre; set => _genre = value; }
        public string Description { get => _description; set => _description = value; }

        public Game(int gameCode, string name, DateTime releaseDate, string genre, string description, bool haveExpansion)
        {
            _gameCode = gameCode;
            _name = name;
            _description = description;
            _genre = genre;
            _releaseDate = releaseDate;
            _haveExpansion = haveExpansion;
        }
    }
}