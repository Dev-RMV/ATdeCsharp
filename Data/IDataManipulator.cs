using Model;

namespace DataManipulation
{
    public interface IDataManipulator
    {
        public bool Create(Game game);
        public bool Update(Game game, int gameCode);
        public bool Delete(int gameCode);
        public List<Game> Search(string s);


    }
}
