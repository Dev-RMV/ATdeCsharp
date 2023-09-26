using Data;
using View;

namespace Controller
{
    internal class ReadController
    {
        private string _userInputString;
        private ReadView _readView = new();
        internal bool Run(MemoryDataManipulator memoryDataManipulatorObject)
        {
            if (memoryDataManipulatorObject.GetList().
                Count == 0)
            {
                throw new Exception("A lista está vazia. **DEV: Exception gerada no Controlador de Pesquisa (Read).**");
            }
            _userInputString = _readView.CollectSearchInput().ToLower();
            if (string.IsNullOrEmpty(_userInputString)) throw new Exception("Entrada vazia. **DEV: Exception gerada no Controlador de Pesquisa (Read).**");
            _readView.listResults(memoryDataManipulatorObject.Search(_userInputString));
            return true;
        }
    }
}
