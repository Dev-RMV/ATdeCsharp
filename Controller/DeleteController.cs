using DataManipulation;
using Model;
using View;

namespace Controller
{
    internal class DeleteController
    {
        private DeleteView _deleteView = new DeleteView();
        internal bool Run(IDataManipulator dataManipulatorObjectInUse)
        {
            if (dataManipulatorObjectInUse.GetList().Count == 0) throw new Exception("A lista está vazia.");
            
            _deleteView.AskGameCode();
            string userInput = Console.ReadLine();
            try
            {
                int gameCode = int.Parse(userInput);                
                if(dataManipulatorObjectInUse.Delete(gameCode) != true) throw new Exception("Erro ao excluir.");
            }
            catch (FormatException)
            {
                if (userInput.ToLower() == "listar")
                {
                    List<Game> templist = dataManipulatorObjectInUse.GetList();
                    foreach (Game item in templist)
                    {
                        _deleteView.ListAllGames(item);
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
