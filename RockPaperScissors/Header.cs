namespace RockPaperScissors;
public class Header
{
    private const string LOGO = "\t***********************************************\n" +
                                  "\t*            KIVI/PAPERI/SAKSET               *\n" +
                                  "\t***********************************************\n";
    private const string GREETING = "\t         * TERVETULOA PELAAMAAN! *             \n";
    private const string RULES = "\t\t   - Kivi voittaa sakset\n" +
                                 "\t\t   - Paperi voittaa kiven\n" +
                                 "\t\t   - Sakset voittaa paperin\n";

    /// <summary>
    /// Clears console and prints out the main logo of the game
    /// </summary>
    public static void ShowLogo()
    {
        Console.Clear();
        Console.WriteLine(LOGO);
    }

    /// <summary>
    /// Prints out wlecome message, game rules and asks confirmation to start a game
    /// </summary>
    public static Game StartGame()
    {
        ConsoleKeyInfo keyInfo;

        Header.ShowLogo();
        Console.WriteLine(GREETING);
        Console.WriteLine("\t\t\tPelin säännöt:");
        Console.WriteLine(RULES);
        Console.WriteLine("\t\tPaina enteriä jatkaaksesi...");
        Console.Write("\tTai jos et haluakaan pelata, paina esc.");

        do
        {
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        } while (keyInfo.Key != ConsoleKey.Enter);
        return new Game();
    }
}
