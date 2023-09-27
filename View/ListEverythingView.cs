using Model;

namespace View
{
    public class ListEverythingView
    {
        public void Show(List<Game> games)
        {
            if (games.Count == 0)
            {
                Console.WriteLine("\nNão há dados a mostrar.\nTente gravar alguma coisa após pressionar qualquer tecla...");
                Console.ReadKey();
                return;
            }
            foreach (var item in games)
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
            Console.WriteLine("Esta é a lista completa. Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
