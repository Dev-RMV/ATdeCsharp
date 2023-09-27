using DataManipulation;
using Model;
using View;

namespace Controller
{
    internal class DeleteController
    {
        private DeleteView _deleteView = new();
        private ReadView _readView = new();
        internal bool Run(IDataManipulator dataManipulatorObjectInUse)
        {
            if (dataManipulatorObjectInUse.GetList().Count == 0) throw new Exception("A lista está vazia.");
            string userInput = _readView.CollectSearchInput();
            int numberOfResults = _readView.listResults(dataManipulatorObjectInUse.Search(userInput));
            if (numberOfResults == 0) throw new Exception("Não há dados");
            userInput = _deleteView.ConfirmDelete(dataManipulatorObjectInUse.GetList());
            if (dataManipulatorObjectInUse.Delete(int.Parse(userInput))) return true;
            return false;
        }
    }
}
