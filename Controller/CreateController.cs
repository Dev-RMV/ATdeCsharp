using DataManipulation;
//using Model;
using View;

namespace Controller
{
    internal class CreateController
    {
        private CreateView _createView;
        internal bool Run(IDataManipulator dataManipulatorObjectInUse)
        {
            _createView = new CreateView();
            //Game tempGame = _createView.CollectAllGameDataFromUser();
            if (dataManipulatorObjectInUse.GameCodeIsUsed(_createView.CollectAllGameDataFromUser().GameCode) == true) throw new Exception("Código indisponível (já consta nos dados) - By CreateController");
            if (dataManipulatorObjectInUse.Create(_createView.CollectAllGameDataFromUser()) != true || _createView.CollectAllGameDataFromUser() == null) throw new Exception("Erro ao incluir");
            return true;

        }
    }
}
