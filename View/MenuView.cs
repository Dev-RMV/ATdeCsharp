namespace View;
using System;

public class MenuView
{
    public void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu principal do AT de Fundamentos de C#\n");
        Console.Write("Considerando que a entidade escolhida foi jogo, escolha uma opção:\n");
        Console.WriteLine("1-Incluir");
        Console.WriteLine("2-Alterar");
        Console.WriteLine("3-Excluir");
        Console.WriteLine("4-Pesquisar");
        Console.WriteLine("5-LISTAR TUDO NO _memoryDataManipulatorObject");
        Console.WriteLine("6-SAIR");
        Console.Write("\nOpção:");
    }
}



