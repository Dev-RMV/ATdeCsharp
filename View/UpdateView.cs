using Model;

namespace View
{
    public class UpdateView
    {
        public void AskGameCode()
        {
            Console.Clear();
            Console.WriteLine("Esta é a tela de ALTERAÇÃO");
            Console.WriteLine("Insira o código do jogo, ou digite LISTAR para listar os códigos... \n");
            Console.Write("Resposta: ");
        }

        public void ListAllGames(Game game)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Código: " + game.GameCode);
            Console.WriteLine("Nome: " + game.Name);
            Console.WriteLine("Gênero: " + game.Genre);
            Console.WriteLine("Data de lançamento: " + game.ReleaseDate);
            Console.WriteLine("Idade: " + game.AgeInDays + "dias");
            Console.WriteLine("Descrição: " + game.Description);
            Console.WriteLine("=================================");
        }

        public void AskGameCodeAfterListing()
        {
            Console.WriteLine("\nDada a lista acima, insira o código do jogo.\n");
            Console.Write("Resposta: ");
        }
    }
}
