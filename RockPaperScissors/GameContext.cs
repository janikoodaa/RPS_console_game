using System.Reflection.PortableExecutable;

namespace RockPaperScissors;
public class GameContext : IGameContext
{
    private const string LOGO = "\t***********************************************\n" +
                                  "\t*            KIVI/PAPERI/SAKSET               *\n" +
                                  "\t***********************************************\n";
    private const string GREETING = "\t         * TERVETULOA PELAAMAAN! *             \n";
    private const string RULES = "\t\t   - Kivi voittaa sakset\n" +
                                 "\t\t   - Paperi voittaa kiven\n" +
                                 "\t\t   - Sakset voittaa paperin\n";

    /// <summary>
    /// Initializes the game context in which the the actual game is then run.
    /// </summary>
    public GameContext()
    {
        PrintLogo();
        PrintGreeting();
        PrintRules();

        if (StartPlaying())
        {
            Run();
        }
        ExitGame();
    }

    /// <summary>
    /// Clears console and prints out game logo on top of the console
    /// </summary>
    public void PrintLogo()
    {
        Console.Clear();
        Console.WriteLine(LOGO);
    }

    /// <summary>
    /// Prints out greeting
    /// </summary>
    private static void PrintGreeting()
    {
        Console.WriteLine(GREETING);
    }

    /// <summary>
    /// Prints out the rules for the game
    /// </summary>
    private static void PrintRules()
    {
        Console.WriteLine("\t\t\tPelin säännöt:");
        Console.WriteLine(RULES);
    }

    /// <summary>
    /// Confirms, if the player wants to play a game.
    /// </summary>
    /// <returns>True, if player wants to play, otherwise false</returns>
    private static bool StartPlaying()
    {
        ConsoleKeyInfo keyInfo;
        Console.Write("\nPaina enteriä aloittaaksesi pelin, tai jos et haluakaan pelata, paina esc.");
        do
        {
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Environment.Exit(0);
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        return true;
    }

    /// <summary>
    /// Starts a new round of the game as long as player wants to play.
    /// </summary>
    private void Run()
    {
        bool continuePlaying;
        do
        {
            Game game = new(this);
            game.Start();
            continuePlaying = Game.ConfirmContinue();
        } while (continuePlaying);
    }

    /// <summary>
    /// Clears console on exit.
    /// </summary>
    private static void ExitGame()
    {
        Console.Clear();
    }

}
