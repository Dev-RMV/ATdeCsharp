using DataManipulation;
using Model;

namespace Data
{
    public class MemoryDataManipulator : IDataManipulator
    {
        private List<Game> _list = new List<Game>();

        public List<Game> GetList()
        {
            return _list;
        }

        public bool Create(Game game)
        {
            if (game == null) return false;
            _list.Add(game);
            return true;
        }
        public bool Delete(int gameCode)
        {
            try
            {
                foreach (Game item in _list)
                {
                    if (item.GameCode == gameCode)
                    {
                        _list.Remove(item);
                        return true;
                    }
                }
                return false;
            }
            catch { return false; }
        }

        public bool gameCodeIsUsed(int gameCode)
        {
            foreach (var item in _list)
            {
                if (item.GameCode == gameCode) return true;
            }
            return false;
        }
        public bool Update(Game updates, int gameCode)
        {
            foreach (var item in _list)
            {
                if (item.GameCode == gameCode)
                {
                    item.GameCode = updates.GameCode;
                    item.Name = updates.Name;
                    item.ReleaseDate = updates.ReleaseDate;
                    item.HaveExpansion = updates.HaveExpansion;
                    item.Genre = updates.Genre;
                    item.Description = updates.Description;
                    return true;
                }
            }
            return false;
        }
        public List<Game> Search(string s)
        {
            s = s.ToLower();
            try
            {
                if (_list.Count == 0) { return _list; }
                List<Game> results = new();
                foreach (var item in _list)
                {
                    if (s.Contains(item.GameCode.ToString())) results.Add(item);
                    if (item.Name.ToLower().Contains(s)) results.Add(
                        item);
                    if (item.Description.ToLower().Contains(s)) results.Add(item);
                    if (item.ReleaseDate.Year.ToString().ToLower().Contains(s)) results.Add(
                        item);
                    if (item.Genre.ToLower().Contains(s)) results.Add(item);
                }

                /*TODO: Refatorar essa parte e perguntar qual o erro.
                 * Abaixo eu fiz uma "gambiarra".
                 * Estava tendo problemas com CAST em tempo de execução (não compilação), 
                 * pois o resultado do .Distinct() não era reconhecido como uma List<game>
                 * mesmo depois de um cast. O resultado do cast era sempre null. Então,
                 criei resultsTemp para criar um retorno válido.*/

                List<Game> resultsTemp = new();
                foreach (Game item in results.Distinct())
                {
                    resultsTemp.Add(item);
                }
                return resultsTemp;
            }
            catch { return null; }
        }
    }
}