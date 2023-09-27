using DataManipulation;
using Model;
using View;

namespace Controller
{
    internal class UpdateController
    {
        private UpdateView _updateView = new();
        private ReadView _readView = new();
        private CreateView _createView = new();
        internal bool Run(IDataManipulator dataManipulatorObjectInUse)
        {
            if (dataManipulatorObjectInUse.GetList().Count == 0) throw new Exception("A lista está vazia.");
            string userInput = _readView.CollectSearchInput();
            int numberOfResults=_readView.listResults(dataManipulatorObjectInUse.Search(userInput));
            if (numberOfResults == 0) throw new Exception("Não há dados");
            userInput = _updateView.GetUpdateCodeFromUser();
            Game updatedGame = _createView.CollectAllGameDataFromUser();
            if (dataManipulatorObjectInUse.Update(updatedGame, int.Parse(userInput))) return true;
            return false;
        }
    }
}
