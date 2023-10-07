namespace RockPaperScissors;
public class Game
{
    public bool WantToPlay { get; set; }
    public int TotalRoundCount { get; set; }
    public int CurrentRound { get; set; } = 1;
    public int PlayerWins { get; set; } = 0;
    public int ComputerWins { get; set; } = 0;
    private readonly KeyValuePair<char, string>[] Options = new KeyValuePair<char, string>[3] { new('k', "kivi"), new('p', "paperi"), new('s', "sakset") };

    public Game()
    {
        WantToPlay = true;
    }

    /// <summary>
    /// Asks for user input on how many rounds of the game will be played
    /// </summary>
    public void AskRoundCount()
    {
        int rounds;
        do
        {
            Header.ShowLogo();
            Console.WriteLine("\t\tMontako kierrosta haluat pelata?");
            Console.WriteLine("\t\t1 - 3 kierrosta = PIKAPELI");
            Console.WriteLine("\t\t4 - 10 kierrosta = NORMAALI PELI");
            Console.WriteLine("\t\t10 - 20 kierrosta = MARATONPELI");
            Console.Write("\n\t\tKierrosten määrä: ");
            string? input = Console.ReadLine();
            bool success = int.TryParse(input, out rounds);
            if (!success)
            {
                rounds = 0;
                Console.Write("\n\tVirheellinen syöte, anna luku väliltä 1 - 20!");
                Thread.Sleep(1000);
            }
            if (success && (rounds < 1 || rounds > 20))
            {
                Console.Write("\n\tVirheellinen syöte, anna luku väliltä 1 - 20!");
                Thread.Sleep(1000);

            }
        } while (rounds < 1 || rounds > 20);

        Header.ShowLogo();
        TotalRoundCount = rounds;
        Console.WriteLine("\t\t\tPelaat {0} kierrosta!", rounds);
        Thread.Sleep(1000);
    }

    /// <summary>
    /// Executes one round of the game
    /// </summary>
    public void PlayRound()
    {
        ConsoleKeyInfo keyInfo;

        Header.ShowLogo();
        Console.WriteLine($"\t\t\tKIERROS {CurrentRound}\n");
        Console.WriteLine("\t\t\tTee valintasi:");
        foreach (var option in Options)
        {
            Console.WriteLine($"\t\t\t{option.Key} = {option.Value}");
        }
        Console.Write("\t\t\tValintasi: ");
        do
        {
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.K && keyInfo.Key != ConsoleKey.P && keyInfo.Key != ConsoleKey.S);

        string playerSelection = Array.Find(Options, kv => kv.Key == keyInfo.KeyChar).Value;
        Console.Write($"{playerSelection}");
        Thread.Sleep(1000);
        var computerSelection = GetRandomRPS();
        Console.WriteLine();
        Console.WriteLine($"\t\tTietokone valitsi: {computerSelection.Value}\n");
        if (playerSelection == computerSelection.Value)
        {
            Console.WriteLine("\t\tTasapeli, ei pisteitä tältä kierrokselta.");
        }
        else
        {
            Console.WriteLine(CheckIfPlayerWins(playerSelection, computerSelection.Value)
            ? $"\t\t\tSinä voitit!\n\t\tPistetilanne sinä {PlayerWins} - {ComputerWins} tietokone"
            : $"\t\t\tTietokone voitti!\n\t\tPistetilanne sinä {PlayerWins} - {ComputerWins} tietokone");
        }

        Thread.Sleep(3000);
        CurrentRound++;

    }

    /// <summary>
    /// Shows the results of the entire game
    /// </summary>
    public void ShowResult()
    {
        Header.ShowLogo();
        Console.WriteLine();
        Console.WriteLine($"\t{TotalRoundCount} kierrosta pelattu ja päädyttiin tilanteeseen");
        Console.WriteLine("\t\t\tSINÄ - TIETOKONE");
        Console.WriteLine($"\t\t\t   {PlayerWins} - {ComputerWins}");
        if (PlayerWins == ComputerWins)
        {
            Console.WriteLine("\t\t\t  TASAPELI");
        }
        else if (PlayerWins > ComputerWins)
        {
            Console.WriteLine("\t\t\tSINÄ VOITIT!");
        }
        else
        {
            Console.WriteLine("\t\t\tTIETOKONE VOITTI!");
        }
    }

    /// <summary>
    /// Asks, if user wants to play another game
    /// </summary>
    public void AskToContinue()
    {
        ConsoleKeyInfo keyInfo;
        Console.Write("\n\t   Haluaisitko pelata uuden pelin (k/e)?");
        do
        {
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.K && keyInfo.Key != ConsoleKey.E);
        if (keyInfo.Key == ConsoleKey.K)
        {
            Continue();
        }
        if (keyInfo.Key == ConsoleKey.E)
        {
            WantToPlay = false;
        }
    }

    /// <summary>
    /// Get the random computer selection out of the rock, paper and scissors
    /// </summary>
    /// <returns>A random KeyValuePair of the rock, paper and scissors</returns>
    private KeyValuePair<char, string> GetRandomRPS()
    {
        Random rnd = new();
        int index = rnd.Next(0, 2);
        return Options[index];
    }

    /// <summary>
    /// Check if player wins. The case of even should be handled before this method.
    /// </summary>
    /// <param name="playerSelection"></param>
    /// <param name="computerSelection"></param>
    /// <returns>True, if player wins and false, if computer wins</returns>
    private bool CheckIfPlayerWins(string playerSelection, string computerSelection)
    {
        if ((playerSelection == "kivi" && computerSelection == "sakset") || (playerSelection == "paperi" && computerSelection == "kivi") || (playerSelection == "sakset" && computerSelection == "paperi"))
        {
            PlayerWins++;
            return true;
        }
        else
        {
            ComputerWins++;
            return false;
        }
    }

    /// <summary>
    /// Reset counters and calculations, if player wats to play another game.
    /// </summary>
    public void Continue()
    {
        CurrentRound = 1;
        PlayerWins = 0;
        ComputerWins = 0;
        WantToPlay = true;
    }
}
