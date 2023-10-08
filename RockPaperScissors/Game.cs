namespace RockPaperScissors;
public class Game
{
    public int TotalRoundCount { get; set; }
    public int CurrentRound { get; set; }
    public Result GameResult { get; set; }

    private readonly IGameContext _gameContext;
    public Game(IGameContext gameContext)
    {
        _gameContext = gameContext;
        TotalRoundCount = 0;
        CurrentRound = 0;
        GameResult = new Result();
    }

    /// <summary>
    /// Starts a new game
    /// </summary>
    public void Start()
    {
        CurrentRound = 1;
        ChooseRoundCount();
        do
        {
            PlayRound();
        } while (CurrentRound <= TotalRoundCount);
        _gameContext.PrintLogo();
        GameResult.DisplayGameResult();
    }

    /// <summary>
    /// Determine, how many rounds of RPS one game takes
    /// </summary>
    public void ChooseRoundCount()
    {
        int rounds;
        do
        {
            _gameContext.PrintLogo();
            Console.WriteLine("\t   Montako kierrosta haluat pelata (1-20)?\n");
            Console.Write("\t\t   Kierrosten määrä: ");
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

        _gameContext.PrintLogo();
        TotalRoundCount = rounds;
        Console.Write($"\n\t\t\tPelaat {rounds} kierrosta!");
        Thread.Sleep(1000);
    }

    /// <summary>
    /// Ask player for confirmation to play a new game.
    /// </summary>
    /// <returns>True if player wants to play another game, otherwise false.</returns>
    public static bool ConfirmContinue()
    {
        ConsoleKeyInfo keyInfo;
        Console.Write("\nPaina enter, jos haluat pelata uuden pelin, tai jos haluat lopettaa, paina esc.");
        do
        {
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                return false;
            }
        } while (keyInfo.Key != ConsoleKey.Enter);
        return true;
    }


    /// <summary>
    /// Executes one round of the game
    /// </summary>
    private void PlayRound()
    {
        ConsoleKeyInfo keyInfo;

        _gameContext.PrintLogo();
        Console.WriteLine($"\t\t\tKIERROS {CurrentRound}\n");
        Console.WriteLine("\t\t\tTee valintasi:");
        foreach (var option in Jury.RPS)
        {
            Console.WriteLine($"\t\t\t{option.Key} = {option.Value}");
        }
        Console.Write("\t\t\tValintasi: ");
        do
        {
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.K && keyInfo.Key != ConsoleKey.P && keyInfo.Key != ConsoleKey.S);

        string playerSelection = Array.Find(Jury.RPS, kv => kv.Key == keyInfo.KeyChar).Value;
        Console.Write($"{playerSelection}");
        KeyValuePair<char, string> computerSelection = GetRandomRPS();

        Console.Write("\n\t\t\tJännitetään");
        int dotsWritten = 0;
        do
        {
            Console.Write(".");
            dotsWritten++;
            Thread.Sleep(200);
        } while (dotsWritten < 6);
        Console.WriteLine();
        Console.WriteLine($"\n\t\t\tTietokone valitsi: {computerSelection.Value}\n");

        Result roundResult = Jury.EvaluateRound(keyInfo.KeyChar, computerSelection.Key);

        GameResult.LogResult(roundResult);

        roundResult.DisplayRoundResult();

        Console.WriteLine($"\n\t\tPistetilanne sinä {GameResult.PlayerWins} - {GameResult.ComputerWins} tietokone");
        Thread.Sleep(3000);

        CurrentRound++;

    }

    /// <summary>
    /// Get the random computer selection out of the rock, paper and scissors
    /// </summary>
    /// <returns>A random KeyValuePair of the rock, paper and scissors</returns>
    private static KeyValuePair<char, string> GetRandomRPS()
    {
        Random rnd = new();
        int index = rnd.Next(0, 1000);
        return Jury.RPS[index % 3];
    }
}
