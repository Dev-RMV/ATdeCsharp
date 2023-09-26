using Model;
namespace View
{
    public class CreateView
    {
        private int _gameCode;
        private string _name = "";
        private DateTime _releaseDate;
        private string _genre = "";
        private string _description = "";
        private bool _haveExpansion;
        public Game CollectAllGameDataFromUser()
        {
            try
            {
                int dia, mes, ano;
                string userInput = "";
                Console.Clear();
                Console.WriteLine("---- CADASTRO DE JOGO ----\n");
                Console.Write("\nEntre com o código do jogo (números inteiros somente): ");
                _gameCode = int.Parse(Console.ReadLine());
                Console.Write("\nEntre com o nome do jogo: ");
                _name = Console.ReadLine();
                Console.Write("Entre com o ANO do lançamento: ");
                ano = int.Parse(Console.ReadLine());
                Console.Write("Entre com o MÊS do lançamento: ");
                mes = int.Parse(Console.ReadLine());
                Console.Write("Entre com o DIA do lançamento: ");
                dia = int.Parse(Console.ReadLine());
                _releaseDate = new DateTime(ano, mes, dia);
                Console.Write("Entre com o gênero do jogo: ");
                _genre = Console.ReadLine();
                while (userInput.ToLower() != "s" && userInput.ToLower() != "n")
                {
                    Console.Write("O jogo possui expansão? (S/N): ");
                    userInput = Console.ReadLine();
                }
                if (userInput.ToLower() == "s") _haveExpansion = true;
                else _haveExpansion = false;
                Console.Write("Entre com a descrição do jogo: ");
                _description = Console.ReadLine();
                
                return new Game(_gameCode, _name, _releaseDate, _genre, _description, _haveExpansion);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}