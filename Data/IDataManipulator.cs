using Model;

namespace DataManipulation
{
    public interface IDataManipulator
    {
        public List<Game> GetList();
        public bool Create(Game game);
        public bool Update(Game game, int gameCode);
        public bool Delete(int gameCode);
        public List<Game> Search(string s);
        public bool GameCodeIsUsed(int gameCode);
    }
}
