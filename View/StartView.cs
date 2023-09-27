using Model;

namespace View
{
    public class StartView
    {
        public void Run(List<Game> games)
        {
            int gameCount = 0;
            foreach (var item in games)
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
                gameCount++;
                if (gameCount == 5) break;                
            }
            Console.WriteLine($"Estas são as primeiras {gameCount} entidades (jogos).");
            Console.WriteLine("\n****TUTORIAL****");
            Console.WriteLine("-A aplicação possui 2 modos: DISCO e MEMÓRIA, que podem ser alternados em tempo de execução.");
            Console.WriteLine("-Qualquer operação em um modo é feito somente neste tipo de armazenamento. Eles são independentes.");
            Console.WriteLine("-A alteração no modo não acarreta em nenhuma perda de dados.");
            Console.WriteLine("-OBS: Espero com essa funcionalidade facilitar a correção do presente trabalho.");
            Console.WriteLine("-PESQUISA: Ela busca pelo input do usuário no arquivo inteiro (modo DISCO) e no modo MEMÓRIA ela não busca se o jogo tem expansão ou os DIA e MÊS de lançamento, só o ANO. A propriedade AgeInDays não fica salva, por isso não aparece na pesquisa");
            Console.WriteLine("\nAtt, RMV");
            Console.WriteLine("\nPressione qualquer tecla para iniciar.");
            Console.ReadKey();
        }
    }
}
