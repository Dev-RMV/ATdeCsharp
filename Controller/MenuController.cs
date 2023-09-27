using DataManipulation;
using View;
namespace Controller
{
    public class MenuController
    {
        private IDataManipulator _dataManipulatorObjectInUse;
        private MemoryDataManipulator _memoryDataManipulatorObject = new();
        private DiskDataManipulator _diskDataManipulatorObject = new();
        private bool _workWithDisk = true;
        private int _userOption = 0;
        private readonly MenuView _menuView = new();
        private readonly OperationResultView operationResultView = new();
        private bool _appJustLoaded = true;
        private readonly StartView _startView = new();
        public void Run()
        {
            do
            {
                try
                {
                    
                    if (_workWithDisk) _dataManipulatorObjectInUse = _diskDataManipulatorObject;
                    else _dataManipulatorObjectInUse = _memoryDataManipulatorObject;

                    if (_appJustLoaded)
                    {
                        _startView.Run(_diskDataManipulatorObject.GetList());
                        _appJustLoaded = false;
                    }
                    _menuView.ShowMainMenu(_workWithDisk,_dataManipulatorObjectInUse.GetList().Count);
                    _userOption = int.Parse(Console.ReadLine());
                    
                    if (_userOption < 1 || _userOption > 7)
                    {
                        throw new Exception("Opção inválida. Foi digitado algum número fora do intervalo de inteiros I=[1,7]");
                    }
                    else if (_userOption == 1)
                    {
                        //incluir
                        CreateController createController = new();
                        operationResultView.Show(createController.Run(_dataManipulatorObjectInUse));
                    }
                    else if (_userOption == 2)
                    {
                        //alterar
                        UpdateController updateController = new();
                        operationResultView.Show(updateController.Run(_dataManipulatorObjectInUse));
                    }
                    else if (_userOption == 3)
                    {
                        //excluir                        
                        DeleteController deleteController = new();
                        operationResultView.Show(deleteController.Run(_dataManipulatorObjectInUse));
                    }
                    else if (_userOption == 4)
                    {
                        //Search
                        ReadController readController = new();
                        operationResultView.Show(readController.Run(_dataManipulatorObjectInUse));
                    }
                    else if (_userOption == 5)
                    {
                        ListEverythingView listEverythingView = new();
                        listEverythingView.Show(_dataManipulatorObjectInUse.GetList());
                    }
                    else if (_userOption == 6)
                    {
                        _workWithDisk = !_workWithDisk;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}\nPressione qualquer tecla...");
                    Console.ReadKey();
                }
            } while (_userOption != 7);
            ExitProgramView exitProgramView = new();
            exitProgramView.EndOfProgram();
        }
    }
}