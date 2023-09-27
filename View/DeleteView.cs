using Model;

namespace View
{
    public class DeleteView
    {
        public string ConfirmDelete(List<Game> games)
        {
            if (games.Count == 0) throw new Exception("Não há dados.");
            Console.WriteLine("\nDada a lista acima, insira o código do jogo a EXCLUIR.\n");
            Console.Write("Resposta: ");
            string userInput = Console.ReadLine();
            foreach (Game item in games)
            {
                if (item.GameCode == int.Parse(userInput))
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
                    break;
                }
            }
            Console.Write("\nTem certeza?!?! (S/N): ");
            string confirmation=Console.ReadLine();
            if (confirmation.ToLower() == "s") return userInput;
            else throw new Exception("Exclusão cancelada");
        }
    }
}
