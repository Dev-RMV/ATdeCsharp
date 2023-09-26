
namespace View
{
    public class OperationResultView
    {
        public void Show(bool result)
        {
            if (result)
            {
                Console.WriteLine("\nOperação bem sucedida! Pressione qualquer tecla para continuar...");
            }
            else
            {
                Console.WriteLine("\nOperação bem sucedida! Pressione qualquer tecla para continuar...");
            }
            Console.ReadKey();
        }
    }
}
