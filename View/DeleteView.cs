namespace View
{
    public class DeleteView
    {
        public void AskGameCode()
        {
            Console.Clear();
            Console.WriteLine("Esta é a tela de EXCLUSÃO");
            Console.WriteLine("Insira o código do jogo, ou digite LISTAR para listar os códigos... \n");
            Console.Write("Resposta: ");
        }

        public void listGameCodeAndName(int gameCode, string name)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Código: " + gameCode);
            Console.WriteLine("Nome: " + name);
            Console.WriteLine("=================================");
        }

        public void AskGameCodeAfterListing()
        {
            Console.WriteLine("\nDada a lista acima, insira o código do jogo.\n");
            Console.Write("Resposta: ");
        }
    }
}
