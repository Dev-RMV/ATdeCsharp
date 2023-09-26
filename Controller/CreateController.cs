using Data;
using Model;
using View;

namespace Controller
{
    internal class CreateController
    {
        private CreateView _createView;
        internal bool Run(MemoryDataManipulator memoryDataManipulatorObject)
        {
            _createView = new CreateView();
            Game tempGame = _createView.CollectAllGameDataFromUser();
            if (memoryDataManipulatorObject.gameCodeIsUsed(tempGame.GameCode) == true) throw new Exception("Código indisponível (já consta nos dados) - By _objManipuladorDeDados");
            if (memoryDataManipulatorObject.Create(tempGame) != true || tempGame == null) throw new Exception("Erro ao incluir");
            return true;
        }
    }
}
