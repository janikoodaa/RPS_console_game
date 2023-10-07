// See https://aka.ms/new-console-template for more information

using RockPaperScissors;

Game game = Header.StartGame();
do
{
    game.AskRoundCount();

    do
    {
        game.PlayRound();
    } while (game.TotalRoundCount - game.CurrentRound >= 0);

    game.ShowResult();
    game.AskToContinue();

} while (game.WantToPlay);
