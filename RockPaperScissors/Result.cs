namespace RockPaperScissors;
public class Result
{
    public int PlayerWins { get; private set; } = 0;
    public int ComputerWins { get; private set; } = 0;
    public int Evens { get; private set; } = 0;

    /// <summary>
    /// Sets point for player
    /// </summary>
    public void PlayerWonTheRound()
    {
        PlayerWins++;
    }

    /// <summary>
    /// Sets point for computer
    /// </summary>
    public void ComputerWonTheRound()
    {
        ComputerWins++;
    }

    /// <summary>
    /// Sets value for even result
    /// </summary>
    public void TheRoundWasEven()
    {
        Evens++;
    }

    /// <summary>
    /// Updates overall game result after the round has been evaluated.
    /// </summary>
    /// <param name="result">Result of a single round</param>
    public void LogResult(Result result)
    {
        PlayerWins += result.PlayerWins;
        ComputerWins += result.ComputerWins;
        Evens += result.Evens;
    }

    /// <summary>
    /// Prints out the result of a single round
    /// </summary>
    public void DisplayRoundResult()
    {
        if (Evens == 1)
        {
            Console.WriteLine($"\t\tTasapeli, ei pisteitä tältä kierrokselta.");
        }
        if (PlayerWins == 1)
        {
            Console.WriteLine($"\t\t\tSinä voitit!");
        }
        if (ComputerWins == 1)
        {
            Console.WriteLine($"\t\t\tTietokone voitti!");
        }
    }

    /// <summary>
    /// Prints out the result of the entire game
    /// </summary>
    public void DisplayGameResult()
    {
        Console.WriteLine($"\t\tPelasit yhteensä {PlayerWins + ComputerWins + Evens} kierrosta\n");
        Console.WriteLine("\t\t\tPELIN TULOKSET\n");
        Console.WriteLine($"\t\t     SINÄ {PlayerWins} - {ComputerWins} TIETOKONE\n");
        if (PlayerWins == ComputerWins)
        {
            Console.WriteLine("\t\t   TASAPELI");
        }
        if (PlayerWins > ComputerWins)
        {
            Console.WriteLine("\t\t     ONNEA, SINÄ VOITIT!");
        }
        if (PlayerWins < ComputerWins)
        {
            Console.WriteLine("\t   HÄVISIT, PAREMPI TUURI ENSI KERRALLA!");
        }
        Thread.Sleep(3000);
    }

}
