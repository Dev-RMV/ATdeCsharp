using Data;
using Model;
using View;

namespace Controller
{
    internal class UpdateController
    {
        private UpdateView _updateView = new();
        internal bool Run(MemoryDataManipulator memoryDataManipulatorObject)
        {
            if (memoryDataManipulatorObject.GetList().Count == 0) throw new Exception("A lista está vazia.");

            _updateView.AskGameCode();
            string userInput = Console.ReadLine();
            try
            {
                int gameCode = int.Parse(userInput);
            }
            catch (FormatException)
            {
                if (userInput.ToLower() == "listar")
                {
                    List<Game> tempList = memoryDataManipulatorObject.GetList();
                    foreach (Game item in tempList)
                    {
                        _updateView.listGameCodeAndName(item.GameCode, item.Name);
                        _updateView.AskGameCodeAfterListing();
                        int gameCode = int.Parse(Console.ReadLine());
                        CreateView createView = new CreateView();
                        Game updates = createView.CollectAllGameDataFromUser();
                        if (memoryDataManipulatorObject.Update(updates, gameCode) != true) throw new Exception("Erro ao alterar.");
                        return true;
                    }
                }
                else throw new Exception("Entrada Inválida");                     
            }
            return true;
        }
    }
}
