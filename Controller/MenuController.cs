using Data;
using View;
namespace Controller
{
    public class MenuController
    {
        private MemoryDataManipulator _memoryDataManipulatorObject = new();
        private int _userOption = 0;
        private readonly MenuView _menuView = new();
        private readonly OperationResultView operationResultView = new();
        public void Run()
        {
            do
            {
                try
                {
                    _menuView.ShowMainMenu();
                    _userOption = int.Parse(Console.ReadLine());
                    if (_userOption < 1 || _userOption > 6)
                    {
                        throw new Exception("Opção inválida. Foi digitado algum número fora do intervalo de inteiros I=[1,5]");
                    }
                    else if (_userOption == 1)
                    {
                        //incluir
                        CreateController createController = new();
                        operationResultView.Show(createController.Run(_memoryDataManipulatorObject));
                    }
                    else if (_userOption == 2)
                    {
                        //alterar
                        UpdateController updateController = new();
                        operationResultView.Show(updateController.Run(_memoryDataManipulatorObject));
                    }
                    else if (_userOption == 3)
                    {
                        //excluir                        
                        DeleteController deleteController = new();
                        operationResultView.Show(deleteController.Run(_memoryDataManipulatorObject));
                    }
                    else if (_userOption == 4)
                    {
                        //Search
                        ReadController readController = new();
                        operationResultView.Show(readController.Run(_memoryDataManipulatorObject));
                    }
                    else if (_userOption == 5)
                    {
                        foreach (var item in _memoryDataManipulatorObject.GetList())
                        {
                            Console.WriteLine("\n---------------------------------------------");
                            Console.WriteLine($"Código: {item.GameCode}");
                            Console.WriteLine($"Nome: {item.Name}");
                            Console.WriteLine($"Data de Lançamento: {item.ReleaseDate.Day}/{item.ReleaseDate.Month}/{item.ReleaseDate.Year}");
                            Console.WriteLine($"Gênero: {item.Genre}");
                            Console.Write($"Possui Expansão: ");
                            if (item.HaveExpansion) Console.WriteLine("Sim"); else Console.WriteLine("Não");
                            Console.WriteLine($"Dias desde o lançamento: {item.AgeInDays}");
                            Console.WriteLine($"Descrição: {item.Description}");
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.WriteLine("Pressione 1 tecla qq...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}\nPressione qualquer tecla...");
                    Console.ReadKey();
                }
            } while (_userOption != 6);
            ExitProgramView exitProgramView = new();
            exitProgramView.EndOfProgram();
        }
    }
}