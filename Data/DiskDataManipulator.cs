using Model;

namespace DataManipulation
{
    public class DiskDataManipulator : IDataManipulator
    {
        private DirectoryInfo dir = new DirectoryInfo(@$".{Path.DirectorySeparatorChar}savedData");

        public List<Game> GetList()
        {
            if (!dir.Exists) dir.Create();
            if (NumberOfDotGameSavedFiles(dir) == 0) throw new Exception($"Não existem arquivos no diretório {dir}.");
            List<Game> results = new();
            foreach (var file in dir.GetFiles(@"*.game"))
            {
                string[] fileContent = File.ReadAllLines(file.FullName);
                Game gameTemp = new(
                  int.Parse(fileContent[0]),
                  fileContent[1],
                  DateTime.Parse(fileContent[2]),
                  fileContent[3],
                  fileContent[4],
                  bool.Parse(fileContent[5])
                    );
                results.Add(gameTemp);
            };
            return results;
        }

        public int NumberOfDotGameSavedFiles(DirectoryInfo dir)
        {
            if (!dir.Exists) dir.Create();
            return dir.GetFiles(@"*.game").Length;
        }


        public bool Create(Game game)
        {
            if (!dir.Exists) dir.Create();
            string fileName = $@"{dir}{Path.DirectorySeparatorChar}{game.GameCode}.game";
            if (GameCodeIsUsed(game.GameCode)) throw new Exception($"O código {game.GameCode} já está sendo usado.");
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine(game.GameCode);
                sw.WriteLine(game.Name);
                sw.WriteLine(game.ReleaseDate);
                sw.WriteLine(game.Genre);
                sw.WriteLine(game.Description);
                sw.WriteLine(game.HaveExpansion);
            }
            return true;
        }

        public bool Delete(int gameCode)
        {
            if (!dir.Exists) dir.Create();
            string fileName = $@"{dir}{Path.DirectorySeparatorChar}{gameCode}.game";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                return true;
            }
            return false;
        }

        public List<Game> Search(string s)
        {
            if (!dir.Exists) dir.Create();
            if (NumberOfDotGameSavedFiles(dir) == 0) throw new Exception($"Não existem arquivos no diretório {dir}.");
            List<Game> results = new();
            foreach (var file in dir.GetFiles(@"*.game"))
            {
                string[] fileContent = File.ReadAllLines(file.FullName);
                foreach (string line in fileContent)
                {
                    if (line.ToLower().Contains(s.ToLower()))
                    {
                        Game gameTemp = new(
                          int.Parse(fileContent[0]),
                          fileContent[1],
                          DateTime.Parse(fileContent[2]),
                          fileContent[3],
                          fileContent[4],
                          bool.Parse(fileContent[5])
                            );
                        results.Add(gameTemp);
                    };
                }
            }
            List<Game> resultsTemp = new();
            foreach (Game item in results.Distinct())
            {
                resultsTemp.Add(item);
            }
            return resultsTemp;
        }

        /*
         * O Update na realidade cria um novo arquivo e deleta o antigo
         * caso os códigos sejam diferentes. Sobrescrever sempre não funcionaria
         * pois quando o arquivo é gerado, ele é nomeado com o gameCode.
         * Para resolver isso, eu teria que renomear o arquivo que sofre
         * Update, coisa que eu não parei para pesquisar sobre.
        */
        public bool Update(Game updates, int gameCode)
        {
            if (!dir.Exists) dir.Create();
            string fileNameOld = $@"{dir}{Path.DirectorySeparatorChar}{gameCode}.game";
            if (File.Exists(fileNameOld) == false) return false;
            string fileNameNew = $@"{dir}{Path.DirectorySeparatorChar}{updates.GameCode}.game";
            using (StreamWriter sw = File.CreateText(fileNameNew))
            {
                sw.WriteLine(updates.GameCode);
                sw.WriteLine(updates.Name);
                sw.WriteLine(updates.ReleaseDate);
                sw.WriteLine(updates.Genre);
                sw.WriteLine(updates.Description);
                sw.WriteLine(updates.HaveExpansion);
            }
            if (fileNameOld != fileNameNew) File.Delete(fileNameOld);
            return true;
        }

        public bool GameCodeIsUsed(int gameCode)
        {
            string fileName = $@"{dir}{Path.DirectorySeparatorChar}{gameCode}.game";
            if (File.Exists(fileName)) return true;
            return false;
        }
    }
}