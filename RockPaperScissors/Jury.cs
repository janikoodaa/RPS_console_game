namespace RockPaperScissors;
public class Jury
{
    public static readonly KeyValuePair<char, string>[] RPS = new KeyValuePair<char, string>[3] { new('k', "kivi"), new('p', "paperi"), new('s', "sakset") };

    /// <summary>
    /// Evaluates round selections and determines, who wins.
    /// </summary>
    /// <param name="playerSelection">Player made selection in char</param>
    /// <param name="computerSelection">Computer made selection in char</param>
    /// <returns>Result object</returns>
    public static Result EvaluateRound(char playerSelection, char computerSelection)
    {
        Result roundResult = new();

        int playerIndex = Array.FindIndex(RPS, rps => rps.Key == playerSelection);
        int computerIndex = Array.FindIndex(RPS, rps => rps.Key == computerSelection);

        if (playerIndex - computerIndex == 0)
        {
            roundResult.TheRoundWasEven();
        }
        else if ((playerIndex != 0 && playerIndex - computerIndex == 1) || (playerIndex == 0 && playerIndex + 3 - computerIndex == 1))
        {
            roundResult.PlayerWonTheRound();
        }
        else
        {
            roundResult.ComputerWonTheRound();
        }

        return roundResult;
    }
}
