using Model;
namespace View
{
    public class ReadView
    {
        private string _userInputString;
        public string CollectSearchInput()
        {
            Console.Clear();
            Console.WriteLine("Esta é a tela de pesquisa. Pesquise qualquer coisa...\n");
            Console.Write("Pesquisar por: ");
            _userInputString = Console.ReadLine();
           return _userInputString.ToLower();
        }
        public void listResults(List<Game> results)
        {
            Console.Clear();            
            Console.WriteLine("Foram encontrados um total de "+results.Count+" resultado(s) da pesquisa por: " + _userInputString);
            foreach (Game item in results)
            {
                Console.WriteLine("\n---------------------------------------------");
                Console.WriteLine($"Código: {item.GameCode}");
                Console.WriteLine($"Nome: {item.Name}");
                Console.WriteLine($"Data de Lançamento: {item.ReleaseDate.Day}/{item.ReleaseDate.Month}/{item.ReleaseDate.Year}");
                Console.WriteLine($"Gênero: {item.Genre}");
                Console.Write($"Possui Expansão: ");
                if (item.HaveExpansion) Console.WriteLine("Sim"); else Console.WriteLine("Não");
                Console.WriteLine($"Dias desde o lançamento: {item.AgeInDays}");
                Console.WriteLine($"Descrição: {item.Description}");
                Console.WriteLine("---------------------------------------------");
            }            
        }
    }
}
