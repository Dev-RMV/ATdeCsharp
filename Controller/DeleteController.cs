using Data;
using Model;
using View;

namespace Controller
{
    internal class DeleteController
    {
        private DeleteView _deleteView = new DeleteView();
        internal bool Run(MemoryDataManipulator memoryDataManipulatorObject)
        {
            if (memoryDataManipulatorObject.GetList().Count == 0) throw new Exception("A lista está vazia.");
            
            _deleteView.AskGameCode();
            string userInput = Console.ReadLine();
            try
            {
                int gameCode = int.Parse(userInput);                
                if(memoryDataManipulatorObject.Delete(gameCode) != true) throw new Exception("Erro ao excluir.");
            }
            catch (FormatException)
            {
                if (userInput.ToLower() == "listar")
                {
                    List<Game> templist = memoryDataManipulatorObject.GetList();
                    foreach (Game item in templist)
                    {
                        _deleteView.listGameCodeAndName(item.GameCode, item.Name);
                        _deleteView.AskGameCodeAfterListing();
                        int gameCode = int.Parse(Console.ReadLine());                        
                    }
                    return true;
                }
                else throw new Exception("Entrada Inválida");
            }
            return true;
        }
    }
}
