using Model;

namespace View
{
    public class UpdateView
    {
        public string GetUpdateCodeFromUser()
        {
            Console.WriteLine("\nDada a lista acima, insira o código do jogo a ALTERAR.\n");
            Console.Write("Resposta: ");
            string userInput = Console.ReadLine();
            return userInput;            
        }
    }
}
