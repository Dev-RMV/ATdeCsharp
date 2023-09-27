namespace View;

public class MenuView
{
    public void ShowMainMenu(bool WorkWithDisk, int NumberOfSavedItems)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Menu principal do AT de Fundamentos de C#\n");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Considerando que a entidade escolhida foi jogo, escolha uma opção.\n");
        Console.WriteLine("1-Incluir");
        Console.WriteLine("2-Alterar");
        Console.WriteLine("3-Excluir");
        Console.WriteLine("4-Pesquisar");
        Console.Write($"5-LISTAR TUDO O QUE ESTÁ SALVO (Depende do modo de trabalho, atualmente ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(NumberOfSavedItems);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(" itens).");
        Console.Write($"6-Alterar Modo de trabalho... Atualmente: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{(WorkWithDisk?"DISCO":"MEMÓRIA")}");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("7-SAIR");
        Console.Write("\nOpção:");
    }
}



